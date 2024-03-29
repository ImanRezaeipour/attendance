﻿define(["ko"], function (e) {
    e.components.register("spa-widget-manager", { require: "./engine/widget/manager/spa.engine.widget.manager" }),
    e.components.register("spa-widget-loader", { require: "./engine/widget/loader/spa.engine.widget.loader" }),
    e.components.register("spa-widget-modal", { require: "./engine/widget/modal/spa.engine.widget.modal" }),
    e.components.register("spa-widget-empty", { viewModel: function () { }, template: "<span/>" })
});