﻿define(['ko',
        'spa.engine.infrastructure.htmlLoader!/overtime/edit',
        './validator',
        'spa.engine.core.data'],
function (ko, template, validator, dataService) {
    function viewModel(params) {
        var self = this;

        self.id = params.id;
        self.MaxOverTime = ko.observable();
        self.MaxNightWork = ko.observable();
        self.MaxHolidayWork = ko.observable();

        self.spinner = ko.observable('glyphicon glyphicon-floppy-save');

        function getData() {
            dataService.get('/api/overtime/getitem/', self.id).done(function (data) {
                self.MaxOverTime(data.MaxOverTime);
                self.MaxNightWork(data.MaxNightly);
                self.MaxHolidayWork(data.MaxHoliday);
                //Hide Parent Loader
                params.loading(false);
            }, function (error) {

            });
        }

        function toJS() {
            var model = {
                MaxOverTime: self.MaxOverTime(),
                MaxNightly: self.MaxNightWork(),
                MaxHoliday: self.MaxHolidayWork()
            };
            return model;
        }

        //Register Modal Buttons
        function registerButtons() {
            var buttons = [
                {
                    text: 'ذخیره', css: 'btn btn-primary', icon: self.spinner, click: function () {
                        self.validator.validate();
                    }
                },
                {
                    text: 'لغو', css: 'btn btn-danger', icon: '', click: function () {
                        params.context.visible(false);
                        params.context.callback('discard', '');
                    }
                }
            ];

            params.context.registerButtons(buttons);
        };

        //Register Form Validator
        function registerValidator() {
            self.success = function () {
                self.spinner('spa-spiner');
                dataService.put('/api/overtime/edit/', self.id, toJS())
                    .done(function (data) {
                        params.context.visible(false);
                        params.context.callback('save', data);

                    }, function (error) {
                        //error
                    })
            }
            self.error = function () {
                //
            }
            self.validator = new validator(self.success, self.error);
        };

        registerButtons();
        registerValidator();
        getData();
    }

    return {
        viewModel: viewModel,
        template: template
    };
});