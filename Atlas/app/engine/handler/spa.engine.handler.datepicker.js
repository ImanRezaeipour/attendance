﻿define(["jquery", "ko", "spa.engine.infrastructure.cssLoader", "spa.engine.infrastructure.moment.jalali"], function (a, e, t, i) {
    t.load("/DesktopModules/Atlas/app/engine/infrastructure/datepicker/spa.engine.infrastructure.datepicker.css"), e.bindingHandlers.datepicker = {
        init: function (t, n, r) { e.unwrap(n()); options = { isRTL: !0, dateFormat: "yy/mm/dd", changeMonth: !0, changeYear: !0, selectOtherMonths: !0, selectOtherYear: !0 }, a(t).datepicker(options), a(t).change(function () { var e = i(a(this).val(), "jYYYY/jMM/jDD").isValid(); if (e) { var t = i(a(this).val(), "jYYYY/jMM/jDD").toDate(); n()(t) } }) },
        update: function (t, n, r) {
            var s = e.unwrap(n());
            if (s) {
                var o = i(s.toISOString(), "YYYY/MM/DD").isValid();
                if (o) {
                    //var Y = i(s.toISOString(), "YYYY/MM/DD").format("jYYYY/jM/jD");
                    var Y = i(s.toISOString()).format("jYYYY/jM/jD");
                    a(t).val(Y), a(t).parents("form:first").formValidation("revalidateField", a(t).attr("name"))
                }
            }
        }
    }
});