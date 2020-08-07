﻿define(['ko',
        'spa.engine.infrastructure.htmlLoader!/DesktopModules/Atlas/app/component/overtime/create/index.html' + '?ver=' + (new Date()).getTime(),
        'spa.engine.infrastructure.guid',
        './validator',
        'spa.engine.core.data'],
function (ko, template, guid, validator, dataService) {
    function viewModel(params) {
        var self = this;

        params.loading(false);

        self.MaxOverTime = ko.observable();
        self.MaxNightWork = ko.observable();
        self.MaxHolidayWork = ko.observable();

        self.spinner = ko.observable('glyphicon glyphicon-floppy-save');

        function toJS() {
            var model = {
                MaxOverTime: self.MaxOverTime(),
                MaxNightWork: self.MaxNightWork(),
                MaxHolidayWork: self.MaxHolidayWork()
            };
            return model;
        }

        //Register Modal Buttons
        function registerButtons() {
            var buttons = [
                {
                    text: 'ذخیره', css: 'btn btn-primary', icon: self.spinner(), click: function () {
                        self.validator.validate(guid.newGuid());
                    }
                },
                {
                    text: 'لغو', css: 'btn btn-primary', icon: '', click: function () {
                        params.context.visible(false);
                        params.context.callback('cancel', '');
                    }
                }
            ];

            params.context.registerButtons(buttons);
        };
        registerButtons();

        //Register Form Validator
        function registerValidator() {
            self.success = function () {
                //
                self.spinner('spa-spiner');
                dataService.post('/DesktopModules/Atlas/api/overtime/create', toJS())
                    .done(function (data) {
                        params.context.visible(false);
                        params.context.callback('save', data);

                    }, function (error) {
                        //error
                        params.context.visible(false);
                        params.context.callback('cancel', data);
                    })
            }
            self.error = function () {
                //
            }

            self.createOvertimeValidator = new validator(self.success, self.error);
        };
        registerValidator();
    }

    return {
        viewModel: viewModel,
        template: template
    }
});