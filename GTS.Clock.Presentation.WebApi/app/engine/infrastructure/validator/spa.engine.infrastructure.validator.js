﻿if (window.FormValidation = {
    AddOn: {},
    Framework: {},
    I18n: {},
    Validator: {}
},
"undefined" == typeof jQuery)
    throw new Error("FormValidation requires jQuery");
!function (t) {
    var e = t.fn.jquery.split(" ")[0].split(".");
    if (+e[0] < 2 && +e[1] < 9 || 1 === +e[0] && 9 === +e[1] && +e[2] < 1)
        throw new Error("FormValidation requires jQuery version 1.9.1 or higher")
}(jQuery),
function (t) {
    FormValidation.Base = function (e, a, i) {
        this.$form = t(e),
        this.options = t.extend({}, t.fn.formValidation.DEFAULT_OPTIONS, a),
        this._namespace = i || "fv",
        this.$invalidFields = t([]),
        this.$submitButton = null,
        this.$hiddenButton = null,
        this.STATUS_NOT_VALIDATED = "NOT_VALIDATED",
        this.STATUS_VALIDATING = "VALIDATING",
        this.STATUS_INVALID = "INVALID",
        this.STATUS_VALID = "VALID",
        this.STATUS_IGNORED = "IGNORED",
        this.DEFAULT_MESSAGE = t.fn.formValidation.DEFAULT_MESSAGE,
        this._ieVersion = function () {
            for (var t = 3, e = document.createElement("div"), a = e.all || []; e.innerHTML = "<!--[if gt IE " + ++t + "]><br><![endif]-->",
            a[0];)
                ;
            return t > 4 ? t : document.documentMode
        }();
        var r = document.createElement("div");
        this._changeEvent = 9 !== this._ieVersion && "oninput" in r ? "input" : "keyup",
        this._submitIfValid = null,
        this._cacheFields = {},
        this._init()
    }
    ,
    FormValidation.Base.prototype = {
        constructor: FormValidation.Base,
        _exceedThreshold: function (e) {
            var a = this._namespace
              , i = e.attr("data-" + a + "-field")
              , r = this.options.fields[i].threshold || this.options.threshold;
            if (!r)
                return !0;
            var s = -1 !== t.inArray(e.attr("type"), ["button", "checkbox", "file", "hidden", "image", "radio", "reset", "submit"]);
            return s || e.val().length >= r
        },
        _init: function () {
            var e = this
              , a = this._namespace
              , i = {
                  addOns: {},
                  autoFocus: this.$form.attr("data-" + a + "-autofocus"),
                  button: {
                      selector: this.$form.attr("data-" + a + "-button-selector") || this.$form.attr("data-" + a + "-submitbuttons"),
                      disabled: this.$form.attr("data-" + a + "-button-disabled")
                  },
                  control: {
                      valid: this.$form.attr("data-" + a + "-control-valid"),
                      invalid: this.$form.attr("data-" + a + "-control-invalid")
                  },
                  err: {
                      clazz: this.$form.attr("data-" + a + "-err-clazz"),
                      container: this.$form.attr("data-" + a + "-err-container") || this.$form.attr("data-" + a + "-container"),
                      parent: this.$form.attr("data-" + a + "-err-parent")
                  },
                  events: {
                      formInit: this.$form.attr("data-" + a + "-events-form-init"),
                      formPreValidate: this.$form.attr("data-" + a + "-events-form-prevalidate"),
                      formError: this.$form.attr("data-" + a + "-events-form-error"),
                      formSuccess: this.$form.attr("data-" + a + "-events-form-success"),
                      fieldAdded: this.$form.attr("data-" + a + "-events-field-added"),
                      fieldRemoved: this.$form.attr("data-" + a + "-events-field-removed"),
                      fieldInit: this.$form.attr("data-" + a + "-events-field-init"),
                      fieldError: this.$form.attr("data-" + a + "-events-field-error"),
                      fieldSuccess: this.$form.attr("data-" + a + "-events-field-success"),
                      fieldStatus: this.$form.attr("data-" + a + "-events-field-status"),
                      localeChanged: this.$form.attr("data-" + a + "-events-locale-changed"),
                      validatorError: this.$form.attr("data-" + a + "-events-validator-error"),
                      validatorSuccess: this.$form.attr("data-" + a + "-events-validator-success"),
                      validatorIgnored: this.$form.attr("data-" + a + "-events-validator-ignored")
                  },
                  excluded: this.$form.attr("data-" + a + "-excluded"),
                  icon: {
                      valid: this.$form.attr("data-" + a + "-icon-valid") || this.$form.attr("data-" + a + "-feedbackicons-valid"),
                      invalid: this.$form.attr("data-" + a + "-icon-invalid") || this.$form.attr("data-" + a + "-feedbackicons-invalid"),
                      validating: this.$form.attr("data-" + a + "-icon-validating") || this.$form.attr("data-" + a + "-feedbackicons-validating"),
                      feedback: this.$form.attr("data-" + a + "-icon-feedback")
                  },
                  live: this.$form.attr("data-" + a + "-live"),
                  locale: this.$form.attr("data-" + a + "-locale"),
                  message: this.$form.attr("data-" + a + "-message"),
                  onPreValidate: this.$form.attr("data-" + a + "-onprevalidate"),
                  onError: this.$form.attr("data-" + a + "-onerror"),
                  onSuccess: this.$form.attr("data-" + a + "-onsuccess"),
                  row: {
                      selector: this.$form.attr("data-" + a + "-row-selector") || this.$form.attr("data-" + a + "-group"),
                      valid: this.$form.attr("data-" + a + "-row-valid"),
                      invalid: this.$form.attr("data-" + a + "-row-invalid"),
                      feedback: this.$form.attr("data-" + a + "-row-feedback")
                  },
                  threshold: this.$form.attr("data-" + a + "-threshold"),
                  trigger: this.$form.attr("data-" + a + "-trigger"),
                  verbose: this.$form.attr("data-" + a + "-verbose"),
                  fields: {}
              };
            this.$form.attr("novalidate", "novalidate").addClass(this.options.elementClass).on("submit." + a, function (t) {
                t.preventDefault(),
                e.validate()
            }).on("click." + a, this.options.button.selector, function () {
                e.$submitButton = t(this),
                e._submitIfValid = !0
            }),
            (this.options.declarative === !0 || "true" === this.options.declarative) && this.$form.find("[name], [data-" + a + "-field]").each(function () {
                var r = t(this)
                  , s = r.attr("name") || r.attr("data-" + a + "-field")
                  , n = e._parseOptions(r);
                n && (r.attr("data-" + a + "-field", s),
                i.fields[s] = t.extend({}, n, i.fields[s]))
            }),
            this.options = t.extend(!0, this.options, i),
            "string" == typeof this.options.err.parent && (this.options.err.parent = new RegExp(this.options.err.parent)),
            this.options.container && (this.options.err.container = this.options.container,
            delete this.options.container),
            this.options.feedbackIcons && (this.options.icon = t.extend(!0, this.options.icon, this.options.feedbackIcons),
            delete this.options.feedbackIcons),
            this.options.group && (this.options.row.selector = this.options.group,
            delete this.options.group),
            this.options.submitButtons && (this.options.button.selector = this.options.submitButtons,
            delete this.options.submitButtons),
            FormValidation.I18n[this.options.locale] || (this.options.locale = t.fn.formValidation.DEFAULT_OPTIONS.locale),
            (this.options.declarative === !0 || "true" === this.options.declarative) && (this.options = t.extend(!0, this.options, {
                addOns: this._parseAddOnOptions()
            })),
            this.$hiddenButton = t("<button/>").attr("type", "submit").prependTo(this.$form).addClass("fv-hidden-submit").css({
                display: "none",
                width: 0,
                height: 0
            }),
            this.$form.on("click." + this._namespace, '[type="submit"]', function (a) {
                if (!a.isDefaultPrevented()) {
                    var i = t(a.target)
                      , r = i.is('[type="submit"]') ? i.eq(0) : i.parent('[type="submit"]').eq(0);
                    !e.options.button.selector || r.is(e.options.button.selector) || r.is(e.$hiddenButton) || e.$form.off("submit." + e._namespace).submit()
                }
            });
            for (var r in this.options.fields)
                this._initField(r);
            for (var s in this.options.addOns)
                "function" == typeof FormValidation.AddOn[s].init && FormValidation.AddOn[s].init(this, this.options.addOns[s]);
            this.$form.trigger(t.Event(this.options.events.formInit), {
                bv: this,
                fv: this,
                options: this.options
            }),
            this.options.onPreValidate && this.$form.on(this.options.events.formPreValidate, function (t) {
                FormValidation.Helper.call(e.options.onPreValidate, [t])
            }),
            this.options.onSuccess && this.$form.on(this.options.events.formSuccess, function (t) {
                FormValidation.Helper.call(e.options.onSuccess, [t])
            }),
            this.options.onError && this.$form.on(this.options.events.formError, function (t) {
                FormValidation.Helper.call(e.options.onError, [t])
            })
        },
        _initField: function (e) {
            var a = this._namespace
              , i = t([]);
            switch (typeof e) {
                case "object":
                    i = e,
                    e = e.attr("data-" + a + "-field");
                    break;
                case "string":
                    i = this.getFieldElements(e),
                    i.attr("data-" + a + "-field", e)
            }
            if (0 !== i.length && null !== this.options.fields[e] && null !== this.options.fields[e].validators) {
                var r, s, n = this.options.fields[e].validators;
                for (r in n)
                    s = n[r].alias || r,
                    FormValidation.Validator[s] || delete this.options.fields[e].validators[r];
                null === this.options.fields[e].enabled && (this.options.fields[e].enabled = !0);
                for (var o = this, l = i.length, d = i.attr("type"), u = 1 === l || "radio" === d || "checkbox" === d, f = this._getFieldTrigger(i.eq(0)), c = t.map(f, function (t) {
                    return t + ".update." + a
                }).join(" "), h = 0; l > h; h++) {
                    var p = i.eq(h)
                      , m = this.options.fields[e].row || this.options.row.selector
                      , v = p.closest(m)
                      , g = "function" == typeof (this.options.fields[e].container || this.options.fields[e].err || this.options.err.container) ? (this.options.fields[e].container || this.options.fields[e].err || this.options.err.container).call(this, p, this) : this.options.fields[e].container || this.options.fields[e].err || this.options.err.container
                      , A = g && "tooltip" !== g && "popover" !== g ? t(g) : this._getMessageContainer(p, m);
                    g && "tooltip" !== g && "popover" !== g && A.addClass(this.options.err.clazz),
                    A.find("." + this.options.err.clazz.split(" ").join(".") + "[data-" + a + "-validator][data-" + a + '-for="' + e + '"]').remove(),
                    v.find("i[data-" + a + '-icon-for="' + e + '"]').remove(),
                    p.off(c).on(c, function () {
                        o.updateStatus(t(this), o.STATUS_NOT_VALIDATED)
                    }),
                    p.data(a + ".messages", A);
                    for (r in n)
                        p.data(a + ".result." + r, this.STATUS_NOT_VALIDATED),
                        u && h !== l - 1 || t("<small/>").css("display", "none").addClass(this.options.err.clazz).attr("data-" + a + "-validator", r).attr("data-" + a + "-for", e).attr("data-" + a + "-result", this.STATUS_NOT_VALIDATED).html(this._getMessage(e, r)).appendTo(A),
                        s = n[r].alias || r,
                        "function" == typeof FormValidation.Validator[s].init && FormValidation.Validator[s].init(this, p, this.options.fields[e].validators[r], r);
                    if (this.options.fields[e].icon !== !1 && "false" !== this.options.fields[e].icon && this.options.icon && this.options.icon.valid && this.options.icon.invalid && this.options.icon.validating && (!u || h === l - 1)) {
                        v.addClass(this.options.row.feedback);
                        var I = t("<i/>").css("display", "none").addClass(this.options.icon.feedback).attr("data-" + a + "-icon-for", e).insertAfter(p);
                        (u ? i : p).data(a + ".icon", I),
                        ("tooltip" === g || "popover" === g) && ((u ? i : p).on(this.options.events.fieldError, function () {
                            v.addClass("fv-has-tooltip")
                        }).on(this.options.events.fieldSuccess, function () {
                            v.removeClass("fv-has-tooltip")
                        }),
                        p.off("focus.container." + a).on("focus.container." + a, function () {
                            o._showTooltip(t(this), g)
                        }).off("blur.container." + a).on("blur.container." + a, function () {
                            o._hideTooltip(t(this), g)
                        })),
                        "string" == typeof this.options.fields[e].icon && "true" !== this.options.fields[e].icon ? I.appendTo(t(this.options.fields[e].icon)) : this._fixIcon(p, I)
                    }
                }
                i.on(this.options.events.fieldSuccess, function (t, e) {
                    var a = o.getOptions(e.field, null, "onSuccess");
                    a && FormValidation.Helper.call(a, [t, e])
                }).on(this.options.events.fieldError, function (t, e) {
                    var a = o.getOptions(e.field, null, "onError");
                    a && FormValidation.Helper.call(a, [t, e])
                }).on(this.options.events.fieldStatus, function (t, e) {
                    var a = o.getOptions(e.field, null, "onStatus");
                    a && FormValidation.Helper.call(a, [t, e])
                }).on(this.options.events.validatorError, function (t, e) {
                    var a = o.getOptions(e.field, e.validator, "onError");
                    a && FormValidation.Helper.call(a, [t, e])
                }).on(this.options.events.validatorIgnored, function (t, e) {
                    var a = o.getOptions(e.field, e.validator, "onIgnored");
                    a && FormValidation.Helper.call(a, [t, e])
                }).on(this.options.events.validatorSuccess, function (t, e) {
                    var a = o.getOptions(e.field, e.validator, "onSuccess");
                    a && FormValidation.Helper.call(a, [t, e])
                }),
                this.onLiveChange(i, "live", function () {
                    o._exceedThreshold(t(this)) && o.validateField(t(this))
                }),
                i.trigger(t.Event(this.options.events.fieldInit), {
                    bv: this,
                    fv: this,
                    field: e,
                    element: i
                })
            }
        },
        _isExcluded: function (e) {
            var a = this._namespace
              , i = e.attr("data-" + a + "-excluded")
              , r = e.attr("data-" + a + "-field") || e.attr("name");
            switch (!0) {
                case !!r && this.options.fields && this.options.fields[r] && ("true" === this.options.fields[r].excluded || this.options.fields[r].excluded === !0):
                case "true" === i:
                case "" === i:
                    return !0;
                case !!r && this.options.fields && this.options.fields[r] && ("false" === this.options.fields[r].excluded || this.options.fields[r].excluded === !1):
                case "false" === i:
                    return !1;
                case !!r && this.options.fields && this.options.fields[r] && "function" == typeof this.options.fields[r].excluded:
                    return this.options.fields[r].excluded.call(this, e, this);
                case !!r && this.options.fields && this.options.fields[r] && "string" == typeof this.options.fields[r].excluded:
                case i:
                    return FormValidation.Helper.call(this.options.fields[r].excluded, [e, this]);
                default:
                    if (this.options.excluded) {
                        "string" == typeof this.options.excluded && (this.options.excluded = t.map(this.options.excluded.split(","), function (e) {
                            return t.trim(e)
                        }));
                        for (var s = this.options.excluded.length, n = 0; s > n; n++)
                            if ("string" == typeof this.options.excluded[n] && e.is(this.options.excluded[n]) || "function" == typeof this.options.excluded[n] && this.options.excluded[n].call(this, e, this) === !0)
                                return !0
                    }
                    return !1
            }
        },
        _getFieldTrigger: function (t) {
            var e = this._namespace
              , a = t.data(e + ".trigger");
            if (a)
                return a;
            var i = t.attr("type")
              , r = t.attr("data-" + e + "-field")
              , s = "radio" === i || "checkbox" === i || "file" === i || "SELECT" === t.get(0).tagName ? "change" : this._ieVersion >= 10 && t.attr("placeholder") ? "keyup" : this._changeEvent;
            return a = ((this.options.fields[r] ? this.options.fields[r].trigger : null) || this.options.trigger || s).split(" "),
            t.data(e + ".trigger", a),
            a
        },
        _getMessage: function (t, e) {
            if (!this.options.fields[t] || !this.options.fields[t].validators)
                return "";
            var a = this.options.fields[t].validators
              , i = a[e] && a[e].alias ? a[e].alias : e;
            if (!FormValidation.Validator[i])
                return "";
            switch (!0) {
                case !!a[e].message:
                    return a[e].message;
                case !!this.options.fields[t].message:
                    return this.options.fields[t].message;
                case !!this.options.message:
                    return this.options.message;
                case !!FormValidation.I18n[this.options.locale] && !!FormValidation.I18n[this.options.locale][i] && !!FormValidation.I18n[this.options.locale][i]["default"]:
                    return FormValidation.I18n[this.options.locale][i]["default"];
                default:
                    return this.DEFAULT_MESSAGE
            }
        },
        _getMessageContainer: function (t, e) {
            if (!this.options.err.parent)
                throw new Error("The err.parent option is not defined");
            var a = t.parent();
            if (a.is(e))
                return a;
            var i = a.attr("class");
            return i && this.options.err.parent.test(i) ? a : this._getMessageContainer(a, e)
        },
        _parseAddOnOptions: function () {
            var t = this._namespace
              , e = this.$form.attr("data-" + t + "-addons")
              , a = this.options.addOns || {};
            if (e) {
                e = e.replace(/\s/g, "").split(",");
                for (var i = 0; i < e.length; i++)
                    a[e[i]] || (a[e[i]] = {})
            }
            var r, s, n, o;
            for (r in a)
                if (FormValidation.AddOn[r]) {
                    if (s = FormValidation.AddOn[r].html5Attributes)
                        for (n in s)
                            o = this.$form.attr("data-" + t + "-addons-" + r.toLowerCase() + "-" + n.toLowerCase()),
                            o && (a[r][s[n]] = o)
                } else
                    delete a[r];
            return a
        },
        _parseOptions: function (e) {
            var a, i, r, s, n, o, l, d, u, f = this._namespace, c = e.attr("name") || e.attr("data-" + f + "-field"), h = {}, p = new RegExp("^data-" + f + "-([a-z]+)-alias$"), m = t.extend({}, FormValidation.Validator);
            t.each(e.get(0).attributes, function (t, e) {
                e.value && p.test(e.name) && (i = e.name.split("-")[2],
                m[e.value] && (m[i] = m[e.value],
                m[i].alias = e.value))
            });
            for (i in m)
                if (a = m[i],
                r = "data-" + f + "-" + i.toLowerCase(),
                s = e.attr(r) + "",
                u = "function" == typeof a.enableByHtml5 ? a.enableByHtml5(e) : null,
                u && "false" !== s || u !== !0 && ("" === s || "true" === s || r === s.toLowerCase())) {
                    a.html5Attributes = t.extend({}, {
                        message: "message",
                        onerror: "onError",
                        onsuccess: "onSuccess",
                        transformer: "transformer"
                    }, a.html5Attributes),
                    h[i] = t.extend({}, u === !0 ? {} : u, h[i]),
                    a.alias && (h[i].alias = a.alias);
                    for (d in a.html5Attributes)
                        n = a.html5Attributes[d],
                        o = "data-" + f + "-" + i.toLowerCase() + "-" + d,
                        l = e.attr(o),
                        l && ("true" === l || o === l.toLowerCase() ? l = !0 : "false" === l && (l = !1),
                        h[i][n] = l)
                }
            var v = {
                autoFocus: e.attr("data-" + f + "-autofocus"),
                err: e.attr("data-" + f + "-err-container") || e.attr("data-" + f + "-container"),
                enabled: e.attr("data-" + f + "-enabled"),
                excluded: e.attr("data-" + f + "-excluded"),
                icon: e.attr("data-" + f + "-icon") || e.attr("data-" + f + "-feedbackicons") || (this.options.fields && this.options.fields[c] ? this.options.fields[c].feedbackIcons : null),
                message: e.attr("data-" + f + "-message"),
                onError: e.attr("data-" + f + "-onerror"),
                onStatus: e.attr("data-" + f + "-onstatus"),
                onSuccess: e.attr("data-" + f + "-onsuccess"),
                row: e.attr("data-" + f + "-row") || e.attr("data-" + f + "-group") || (this.options.fields && this.options.fields[c] ? this.options.fields[c].group : null),
                selector: e.attr("data-" + f + "-selector"),
                threshold: e.attr("data-" + f + "-threshold"),
                transformer: e.attr("data-" + f + "-transformer"),
                trigger: e.attr("data-" + f + "-trigger"),
                verbose: e.attr("data-" + f + "-verbose"),
                validators: h
            }
              , g = t.isEmptyObject(v)
              , A = t.isEmptyObject(h);
            return !A || !g && this.options.fields && this.options.fields[c] ? v : null
        },
        _submit: function () {
            var e = this.isValid();
            if (null !== e) {
                var a = e ? this.options.events.formSuccess : this.options.events.formError
                  , i = t.Event(a);
                this.$form.trigger(i),
                this.$submitButton && (e ? this._onSuccess(i) : this._onError(i))
            }
        },
        _onError: function (e) {
            if (!e.isDefaultPrevented()) {
                if ("submitted" === this.options.live) {
                    this.options.live = "enabled";
                    var a = this;
                    for (var i in this.options.fields)
                        !function (e) {
                            var i = a.getFieldElements(e);
                            i.length && a.onLiveChange(i, "live", function () {
                                a._exceedThreshold(t(this)) && a.validateField(t(this))
                            })
                        }(i)
                }
                for (var r = this._namespace, s = 0; s < this.$invalidFields.length; s++) {
                    var n = this.$invalidFields.eq(s)
                      , o = this.isOptionEnabled(n.attr("data-" + r + "-field"), "autoFocus");
                    if (o) {
                        n.focus();
                        break
                    }
                }
            }
        },
        _onFieldValidated: function (e, a) {
            var i = this._namespace
              , r = e.attr("data-" + i + "-field")
              , s = this.options.fields[r].validators
              , n = {}
              , o = 0
              , l = {
                  bv: this,
                  fv: this,
                  field: r,
                  element: e,
                  validator: a,
                  result: e.data(i + ".response." + a)
              };
            if (a)
                switch (e.data(i + ".result." + a)) {
                    case this.STATUS_INVALID:
                        e.trigger(t.Event(this.options.events.validatorError), l);
                        break;
                    case this.STATUS_VALID:
                        e.trigger(t.Event(this.options.events.validatorSuccess), l);
                        break;
                    case this.STATUS_IGNORED:
                        e.trigger(t.Event(this.options.events.validatorIgnored), l)
                }
            n[this.STATUS_NOT_VALIDATED] = 0,
            n[this.STATUS_VALIDATING] = 0,
            n[this.STATUS_INVALID] = 0,
            n[this.STATUS_VALID] = 0,
            n[this.STATUS_IGNORED] = 0;
            for (var d in s)
                if (s[d].enabled !== !1) {
                    o++;
                    var u = e.data(i + ".result." + d);
                    u && n[u]++
                }
            n[this.STATUS_VALID] + n[this.STATUS_IGNORED] === o ? (this.$invalidFields = this.$invalidFields.not(e),
            e.trigger(t.Event(this.options.events.fieldSuccess), l)) : (0 === n[this.STATUS_NOT_VALIDATED] || !this.isOptionEnabled(r, "verbose")) && 0 === n[this.STATUS_VALIDATING] && n[this.STATUS_INVALID] > 0 && (this.$invalidFields = this.$invalidFields.add(e),
            e.trigger(t.Event(this.options.events.fieldError), l))
        },
        _onSuccess: function (t) {
            t.isDefaultPrevented() || this.disableSubmitButtons(!0).defaultSubmit()
        },
        _fixIcon: function (t, e) { },
        _createTooltip: function (t, e, a) { },
        _destroyTooltip: function (t, e) { },
        _hideTooltip: function (t, e) { },
        _showTooltip: function (t, e) { },
        defaultSubmit: function () {
            var e = this._namespace;
            this.$submitButton && t("<input/>").attr({
                type: "hidden",
                name: this.$submitButton.attr("name")
            }).attr("data-" + e + "-submit-hidden", "").val(this.$submitButton.val()).appendTo(this.$form),
            this.$form.off("submit." + e).submit()
        },
        disableSubmitButtons: function (t) {
            return t ? "disabled" !== this.options.live && this.$form.find(this.options.button.selector).attr("disabled", "disabled").addClass(this.options.button.disabled) : this.$form.find(this.options.button.selector).removeAttr("disabled").removeClass(this.options.button.disabled),
            this
        },
        getFieldElements: function (e) {
            if (!this._cacheFields[e])
                if (this.options.fields[e] && this.options.fields[e].selector) {
                    var a = this.$form.find(this.options.fields[e].selector);
                    this._cacheFields[e] = a.length ? a : t(this.options.fields[e].selector)
                } else
                    this._cacheFields[e] = this.$form.find('[name="' + e + '"]');
            return this._cacheFields[e]
        },
        getFieldValue: function (t, e) {
            var a, i = this._namespace;
            if ("string" == typeof t) {
                if (a = this.getFieldElements(t),
                0 === a.length)
                    return null
            } else
                a = t,
                t = a.attr("data-" + i + "-field");
            if (!t || !this.options.fields[t])
                return a.val();
            var r = (this.options.fields[t].validators && this.options.fields[t].validators[e] ? this.options.fields[t].validators[e].transformer : null) || this.options.fields[t].transformer;
            return r ? FormValidation.Helper.call(r, [a, e, this]) : a.val()
        },
        getNamespace: function () {
            return this._namespace
        },
        getOptions: function (t, e, a) {
            var i = this._namespace;
            if (!t)
                return a ? this.options[a] : this.options;
            if ("object" == typeof t && (t = t.attr("data-" + i + "-field")),
            !this.options.fields[t])
                return null;
            var r = this.options.fields[t];
            return e ? r.validators && r.validators[e] ? a ? r.validators[e][a] : r.validators[e] : null : a ? r[a] : r
        },
        getStatus: function (t, e) {
            var a = this._namespace;
            switch (typeof t) {
                case "object":
                    return t.data(a + ".result." + e);
                case "string":
                default:
                    return this.getFieldElements(t).eq(0).data(a + ".result." + e)
            }
        },
        isOptionEnabled: function (t, e) {
            return !this.options.fields[t] || "true" !== this.options.fields[t][e] && this.options.fields[t][e] !== !0 ? !this.options.fields[t] || "false" !== this.options.fields[t][e] && this.options.fields[t][e] !== !1 ? "true" === this.options[e] || this.options[e] === !0 : !1 : !0
        },
        isValid: function () {
            for (var t in this.options.fields) {
                var e = this.isValidField(t);
                if (null === e)
                    return null;
                if (e === !1)
                    return !1
            }
            return !0
        },
        isValidContainer: function (e) {
            var a = this
              , i = this._namespace
              , r = []
              , s = "string" == typeof e ? t(e) : e;
            if (0 === s.length)
                return !0;
            s.find("[data-" + i + "-field]").each(function () {
                var e = t(this);
                a._isExcluded(e) || r.push(e)
            });
            for (var n = r.length, o = 0; n > o; o++) {
                var l = r[o]
                  , d = l.attr("data-" + i + "-field")
                  , u = l.data(i + ".messages").find("." + this.options.err.clazz.split(" ").join(".") + "[data-" + i + "-validator][data-" + i + '-for="' + d + '"]');
                if (!this.options.fields || !this.options.fields[d] || "false" !== this.options.fields[d].enabled && this.options.fields[d].enabled !== !1) {
                    if (u.filter("[data-" + i + '-result="' + this.STATUS_INVALID + '"]').length > 0)
                        return !1;
                    if (u.filter("[data-" + i + '-result="' + this.STATUS_NOT_VALIDATED + '"]').length > 0 || u.filter("[data-" + i + '-result="' + this.STATUS_VALIDATING + '"]').length > 0)
                        return null
                }
            }
            return !0
        },
        isValidField: function (e) {
            var a = this._namespace
              , i = t([]);
            switch (typeof e) {
                case "object":
                    i = e,
                    e = e.attr("data-" + a + "-field");
                    break;
                case "string":
                    i = this.getFieldElements(e)
            }
            if (0 === i.length || !this.options.fields[e] || "false" === this.options.fields[e].enabled || this.options.fields[e].enabled === !1)
                return !0;
            for (var r, s, n, o = i.attr("type"), l = "radio" === o || "checkbox" === o ? 1 : i.length, d = 0; l > d; d++)
                if (r = i.eq(d),
                !this._isExcluded(r))
                    for (s in this.options.fields[e].validators)
                        if (this.options.fields[e].validators[s].enabled !== !1) {
                            if (n = r.data(a + ".result." + s),
                            n === this.STATUS_VALIDATING || n === this.STATUS_NOT_VALIDATED)
                                return null;
                            if (n === this.STATUS_INVALID)
                                return !1
                        }
            return !0
        },
        offLiveChange: function (e, a) {
            if (null === e || 0 === e.length)
                return this;
            var i = this._namespace
              , r = this._getFieldTrigger(e.eq(0))
              , s = t.map(r, function (t) {
                  return t + "." + a + "." + i
              }).join(" ");
            return e.off(s),
            this
        },
        onLiveChange: function (e, a, i) {
            if (null === e || 0 === e.length)
                return this;
            var r = this._namespace
              , s = this._getFieldTrigger(e.eq(0))
              , n = t.map(s, function (t) {
                  return t + "." + a + "." + r
              }).join(" ");
            switch (this.options.live) {
                case "submitted":
                    break;
                case "disabled":
                    e.off(n);
                    break;
                case "enabled":
                default:
                    e.off(n).on(n, function (t) {
                        i.apply(this, arguments)
                    })
            }
            return this
        },
        updateMessage: function (e, a, i) {
            var r = this
              , s = this._namespace
              , n = t([]);
            switch (typeof e) {
                case "object":
                    n = e,
                    e = e.attr("data-" + s + "-field");
                    break;
                case "string":
                    n = this.getFieldElements(e)
            }
            return n.each(function () {
                t(this).data(s + ".messages").find("." + r.options.err.clazz + "[data-" + s + '-validator="' + a + '"][data-' + s + '-for="' + e + '"]').html(i)
            }),
            this
        },
        updateStatus: function (e, a, i) {
            var r = this._namespace
              , s = t([]);
            switch (typeof e) {
                case "object":
                    s = e,
                    e = e.attr("data-" + r + "-field");
                    break;
                case "string":
                    s = this.getFieldElements(e)
            }
            if (!e || !this.options.fields[e])
                return this;
            a === this.STATUS_NOT_VALIDATED && (this._submitIfValid = !1);
            for (var n = this, o = s.attr("type"), l = this.options.fields[e].row || this.options.row.selector, d = "radio" === o || "checkbox" === o ? 1 : s.length, u = 0; d > u; u++) {
                var f = s.eq(u);
                if (!this._isExcluded(f)) {
                    var c, h, p = f.closest(l), m = f.data(r + ".messages"), v = m.find("." + this.options.err.clazz.split(" ").join(".") + "[data-" + r + "-validator][data-" + r + '-for="' + e + '"]'), g = i ? v.filter("[data-" + r + '-validator="' + i + '"]') : v, A = f.data(r + ".icon"), I = "function" == typeof (this.options.fields[e].container || this.options.fields[e].err || this.options.err.container) ? (this.options.fields[e].container || this.options.fields[e].err || this.options.err.container).call(this, f, this) : this.options.fields[e].container || this.options.fields[e].err || this.options.err.container, b = null;
                    if (i)
                        f.data(r + ".result." + i, a);
                    else
                        for (var F in this.options.fields[e].validators)
                            f.data(r + ".result." + F, a);
                    switch (g.attr("data-" + r + "-result", a),
                    a) {
                        case this.STATUS_VALIDATING:
                            b = null,
                            this.disableSubmitButtons(!0),
                            f.removeClass(this.options.control.valid).removeClass(this.options.control.invalid),
                            p.removeClass(this.options.row.valid).removeClass(this.options.row.invalid),
                            A && A.removeClass(this.options.icon.valid).removeClass(this.options.icon.invalid).addClass(this.options.icon.validating).show();
                            break;
                        case this.STATUS_INVALID:
                            b = !1,
                            this.disableSubmitButtons(!0),
                            f.removeClass(this.options.control.valid).addClass(this.options.control.invalid),
                            p.removeClass(this.options.row.valid).addClass(this.options.row.invalid),
                            A && A.removeClass(this.options.icon.valid).removeClass(this.options.icon.validating).addClass(this.options.icon.invalid).show();
                            break;
                        case this.STATUS_IGNORED:
                        case this.STATUS_VALID:
                            c = v.filter("[data-" + r + '-result="' + this.STATUS_VALIDATING + '"]').length > 0,
                            h = v.filter("[data-" + r + '-result="' + this.STATUS_NOT_VALIDATED + '"]').length > 0;
                            var V = v.filter("[data-" + r + '-result="' + this.STATUS_IGNORED + '"]').length;
                            b = c || h ? null : v.filter("[data-" + r + '-result="' + this.STATUS_VALID + '"]').length + V === v.length,
                            f.removeClass(this.options.control.valid).removeClass(this.options.control.invalid),
                            b === !0 ? (this.disableSubmitButtons(this.isValid() === !1),
                            a === this.STATUS_VALID && f.addClass(this.options.control.valid)) : b === !1 && (this.disableSubmitButtons(!0),
                            a === this.STATUS_VALID && f.addClass(this.options.control.invalid)),
                            A && (A.removeClass(this.options.icon.invalid).removeClass(this.options.icon.validating).removeClass(this.options.icon.valid),
                            (a === this.STATUS_VALID || V !== v.length) && A.addClass(c ? this.options.icon.validating : null === b ? "" : b ? this.options.icon.valid : this.options.icon.invalid).show());
                            var S = this.isValidContainer(p);
                            null !== S && (p.removeClass(this.options.row.valid).removeClass(this.options.row.invalid),
                            (a === this.STATUS_VALID || V !== v.length) && p.addClass(S ? this.options.row.valid : this.options.row.invalid));
                            break;
                        case this.STATUS_NOT_VALIDATED:
                        default:
                            b = null,
                            this.disableSubmitButtons(!1),
                            f.removeClass(this.options.control.valid).removeClass(this.options.control.invalid),
                            p.removeClass(this.options.row.valid).removeClass(this.options.row.invalid),
                            A && A.removeClass(this.options.icon.valid).removeClass(this.options.icon.invalid).removeClass(this.options.icon.validating).hide()
                    }
                    !A || "tooltip" !== I && "popover" !== I ? a === this.STATUS_INVALID ? g.show() : g.hide() : b === !1 ? this._createTooltip(f, v.filter("[data-" + r + '-result="' + n.STATUS_INVALID + '"]').eq(0).html(), I) : this._destroyTooltip(f, I),
                    f.trigger(t.Event(this.options.events.fieldStatus), {
                        bv: this,
                        fv: this,
                        field: e,
                        element: f,
                        status: a
                    }),
                    this._onFieldValidated(f, i)
                }
            }
            return this
        },
        validate: function () {
            if (t.isEmptyObject(this.options.fields))
                return this._submit(),
                this;
            this.$form.trigger(t.Event(this.options.events.formPreValidate)),
            this.disableSubmitButtons(!0),
            this._submitIfValid = !1;
            for (var e in this.options.fields)
                this.validateField(e);
            return this._submit(),
            this._submitIfValid = !0,
            this
        },
        validateField: function (e) {
            var a = this._namespace
              , i = t([]);
            switch (typeof e) {
                case "object":
                    i = e,
                    e = e.attr("data-" + a + "-field");
                    break;
                case "string":
                    i = this.getFieldElements(e)
            }
            if (0 === i.length || !this.options.fields[e] || "false" === this.options.fields[e].enabled || this.options.fields[e].enabled === !1)
                return this;
            for (var r, s, n, o = this, l = i.attr("type"), d = "radio" === l || "checkbox" === l ? 1 : i.length, u = "radio" === l || "checkbox" === l, f = this.options.fields[e].validators, c = this.isOptionEnabled(e, "verbose"), h = 0; d > h; h++) {
                var p = i.eq(h);
                if (!this._isExcluded(p)) {
                    var m = !1;
                    for (r in f) {
                        if (p.data(a + ".dfs." + r) && p.data(a + ".dfs." + r).reject(),
                        m)
                            break;
                        var v = p.data(a + ".result." + r);
                        if (v !== this.STATUS_VALID && v !== this.STATUS_INVALID)
                            if (f[r].enabled !== !1)
                                if (p.data(a + ".result." + r, this.STATUS_VALIDATING),
                                s = f[r].alias || r,
                                n = FormValidation.Validator[s].validate(this, p, f[r], r),
                                "object" == typeof n && n.resolve)
                                    this.updateStatus(u ? e : p, this.STATUS_VALIDATING, r),
                                    p.data(a + ".dfs." + r, n),
                                    n.done(function (t, e, i) {
                                        t.removeData(a + ".dfs." + e).data(a + ".response." + e, i),
                                        i.message && o.updateMessage(t, e, i.message),
                                        o.updateStatus(u ? t.attr("data-" + a + "-field") : t, i.valid === !0 ? o.STATUS_VALID : i.valid === !1 ? o.STATUS_INVALID : o.STATUS_IGNORED, e),
                                        i.valid && o._submitIfValid === !0 ? o._submit() : i.valid !== !1 || c || (m = !0)
                                    });
                                else if ("object" == typeof n && void 0 !== n.valid) {
                                    if (p.data(a + ".response." + r, n),
                                    n.message && this.updateMessage(u ? e : p, r, n.message),
                                    this.updateStatus(u ? e : p, n.valid === !0 ? this.STATUS_VALID : n.valid === !1 ? this.STATUS_INVALID : this.STATUS_IGNORED, r),
                                    n.valid === !1 && !c)
                                        break
                                } else if ("boolean" == typeof n) {
                                    if (p.data(a + ".response." + r, n),
                                    this.updateStatus(u ? e : p, n ? this.STATUS_VALID : this.STATUS_INVALID, r),
                                    !n && !c)
                                        break
                                } else
                                    null === n && (p.data(a + ".response." + r, n),
                                    this.updateStatus(u ? e : p, this.STATUS_IGNORED, r));
                            else
                                this.updateStatus(u ? e : p, this.STATUS_IGNORED, r);
                        else
                            this._onFieldValidated(p, r)
                    }
                }
            }
            return this
        },
        addField: function (e, a) {
            var i = this._namespace
              , r = t([]);
            switch (typeof e) {
                case "object":
                    r = e,
                    e = e.attr("data-" + i + "-field") || e.attr("name");
                    break;
                case "string":
                    delete this._cacheFields[e],
                    r = this.getFieldElements(e)
            }
            r.attr("data-" + i + "-field", e);
            for (var s = r.attr("type"), n = "radio" === s || "checkbox" === s ? 1 : r.length, o = 0; n > o; o++) {
                var l = r.eq(o)
                  , d = this._parseOptions(l);
                d = null === d ? a : t.extend(!0, d, a),
                this.options.fields[e] = t.extend(!0, this.options.fields[e], d),
                this._cacheFields[e] = this._cacheFields[e] ? this._cacheFields[e].add(l) : l,
                this._initField("checkbox" === s || "radio" === s ? e : l)
            }
            return this.disableSubmitButtons(!1),
            this.$form.trigger(t.Event(this.options.events.fieldAdded), {
                field: e,
                element: r,
                options: this.options.fields[e]
            }),
            this
        },
        destroy: function () {
            var t, e, a, i, r, s, n, o, l = this._namespace;
            for (e in this.options.fields)
                for (a = this.getFieldElements(e),
                t = 0; t < a.length; t++) {
                    i = a.eq(t);
                    for (r in this.options.fields[e].validators)
                        i.data(l + ".dfs." + r) && i.data(l + ".dfs." + r).reject(),
                        i.removeData(l + ".result." + r).removeData(l + ".response." + r).removeData(l + ".dfs." + r),
                        o = this.options.fields[e].validators[r].alias || r,
                        "function" == typeof FormValidation.Validator[o].destroy && FormValidation.Validator[o].destroy(this, i, this.options.fields[e].validators[r], r)
                }
            for (e in this.options.fields)
                for (a = this.getFieldElements(e),
                n = this.options.fields[e].row || this.options.row.selector,
                t = 0; t < a.length; t++) {
                    i = a.eq(t),
                    i.data(l + ".messages").find("." + this.options.err.clazz.split(" ").join(".") + "[data-" + l + "-validator][data-" + l + '-for="' + e + '"]').remove().end().end().removeData(l + ".messages").closest(n).removeClass(this.options.row.valid).removeClass(this.options.row.invalid).removeClass(this.options.row.feedback).end().off("." + l).removeAttr("data-" + l + "-field");
                    var d = "function" == typeof (this.options.fields[e].container || this.options.fields[e].err || this.options.err.container) ? (this.options.fields[e].container || this.options.fields[e].err || this.options.err.container).call(this, i, this) : this.options.fields[e].container || this.options.fields[e].err || this.options.err.container;
                    ("tooltip" === d || "popover" === d) && this._destroyTooltip(i, d),
                    s = i.data(l + ".icon"),
                    s && s.remove(),
                    i.removeData(l + ".icon").removeData(l + ".trigger")
                }
            for (var u in this.options.addOns)
                "function" == typeof FormValidation.AddOn[u].destroy && FormValidation.AddOn[u].destroy(this, this.options.addOns[u]);
            this.disableSubmitButtons(!1),
            this.$hiddenButton.remove(),
            this.$form.removeClass(this.options.elementClass).off("." + l).removeData("bootstrapValidator").removeData("formValidation").find("[data-" + l + "-submit-hidden]").remove().end().find('[type="submit"]').off("click." + l)
        },
        enableFieldValidators: function (t, e, a) {
            var i = this.options.fields[t].validators;
            if (a && i && i[a] && i[a].enabled !== e)
                this.options.fields[t].validators[a].enabled = e,
                this.updateStatus(t, this.STATUS_NOT_VALIDATED, a);
            else if (!a && this.options.fields[t].enabled !== e) {
                this.options.fields[t].enabled = e;
                for (var r in i)
                    this.enableFieldValidators(t, e, r)
            }
            return this
        },
        getDynamicOption: function (t, e) {
            var a = "string" == typeof t ? this.getFieldElements(t) : t
              , i = a.val();
            if ("function" == typeof e)
                return FormValidation.Helper.call(e, [i, this, a]);
            if ("string" == typeof e) {
                var r = this.getFieldElements(e);
                return r.length ? r.val() : FormValidation.Helper.call(e, [i, this, a]) || e
            }
            return null
        },
        getForm: function () {
            return this.$form
        },
        getInvalidFields: function () {
            return this.$invalidFields
        },
        getLocale: function () {
            return this.options.locale
        },
        getMessages: function (e, a) {
            var i = this
              , r = this._namespace
              , s = []
              , n = t([]);
            switch (!0) {
                case e && "object" == typeof e:
                    n = e;
                    break;
                case e && "string" == typeof e:
                    var o = this.getFieldElements(e);
                    if (o.length > 0) {
                        var l = o.attr("type");
                        n = "radio" === l || "checkbox" === l ? o.eq(0) : o
                    }
                    break;
                default:
                    n = this.$invalidFields
            }
            var d = a ? "[data-" + r + '-validator="' + a + '"]' : "";
            return n.each(function () {
                s = s.concat(t(this).data(r + ".messages").find("." + i.options.err.clazz + "[data-" + r + '-for="' + t(this).attr("data-" + r + "-field") + '"][data-' + r + '-result="' + i.STATUS_INVALID + '"]' + d).map(function () {
                    var e = t(this).attr("data-" + r + "-validator")
                      , a = t(this).attr("data-" + r + "-for");
                    return i.options.fields[a].validators[e].enabled === !1 ? "" : t(this).html()
                }).get())
            }),
            s
        },
        getSubmitButton: function () {
            return this.$submitButton
        },
        removeField: function (e) {
            var a = this._namespace
              , i = t([]);
            switch (typeof e) {
                case "object":
                    i = e,
                    e = e.attr("data-" + a + "-field") || e.attr("name"),
                    i.attr("data-" + a + "-field", e);
                    break;
                case "string":
                    i = this.getFieldElements(e)
            }
            if (0 === i.length)
                return this;
            for (var r = i.attr("type"), s = "radio" === r || "checkbox" === r ? 1 : i.length, n = 0; s > n; n++) {
                var o = i.eq(n);
                this.$invalidFields = this.$invalidFields.not(o),
                this._cacheFields[e] = this._cacheFields[e].not(o)
            }
            return this._cacheFields[e] && 0 !== this._cacheFields[e].length || delete this.options.fields[e],
            ("checkbox" === r || "radio" === r) && this._initField(e),
            this.disableSubmitButtons(!1),
            this.$form.trigger(t.Event(this.options.events.fieldRemoved), {
                field: e,
                element: i
            }),
            this
        },
        resetField: function (e, a) {
            var i = this._namespace
              , r = t([]);
            switch (typeof e) {
                case "object":
                    r = e,
                    e = e.attr("data-" + i + "-field");
                    break;
                case "string":
                    r = this.getFieldElements(e)
            }
            var s = r.length;
            if (this.options.fields[e])
                for (var n = 0; s > n; n++)
                    for (var o in this.options.fields[e].validators)
                        r.eq(n).removeData(i + ".dfs." + o);
            if (a) {
                var l = r.attr("type");
                "radio" === l || "checkbox" === l ? r.prop("checked", !1).removeAttr("selected") : r.val("")
            }
            return this.updateStatus(e, this.STATUS_NOT_VALIDATED),
            this
        },
        resetForm: function (e) {
            for (var a in this.options.fields)
                this.resetField(a, e);
            return this.$invalidFields = t([]),
            this.$submitButton = null,
            this.disableSubmitButtons(!1),
            this
        },
        revalidateField: function (t) {
            return this.updateStatus(t, this.STATUS_NOT_VALIDATED).validateField(t),
            this
        },
        setLocale: function (e) {
            return this.options.locale = e,
            this.$form.trigger(t.Event(this.options.events.localeChanged), {
                locale: e,
                bv: this,
                fv: this
            }),
            this
        },
        updateOption: function (t, e, a, i) {
            var r = this._namespace;
            return "object" == typeof t && (t = t.attr("data-" + r + "-field")),
            this.options.fields[t] && this.options.fields[t].validators[e] && (this.options.fields[t].validators[e][a] = i,
            this.updateStatus(t, this.STATUS_NOT_VALIDATED, e)),
            this
        },
        validateContainer: function (e) {
            var a = this
              , i = this._namespace
              , r = []
              , s = "string" == typeof e ? t(e) : e;
            if (0 === s.length)
                return this;
            s.find("[data-" + i + "-field]").each(function () {
                var e = t(this);
                a._isExcluded(e) || r.push(e)
            });
            for (var n = r.length, o = 0; n > o; o++)
                this.validateField(r[o]);
            return this
        }
    },
    t.fn.formValidation = function (e) {
        var a = arguments;
        return this.each(function () {
            var i = t(this)
              , r = i.data("formValidation")
              , s = "object" == typeof e && e;
            if (!r) {
                var n = (s.framework || i.attr("data-fv-framework") || "bootstrap").toLowerCase()
                  , o = n.substr(0, 1).toUpperCase() + n.substr(1);
                if ("undefined" == typeof FormValidation.Framework[o])
                    throw new Error("The class FormValidation.Framework." + o + " is not implemented");
                r = new FormValidation.Framework[o](this, s),
                i.addClass("fv-form-" + n).data("formValidation", r)
            }
            "string" == typeof e && r[e].apply(r, Array.prototype.slice.call(a, 1))
        })
    }
    ,
    t.fn.formValidation.Constructor = FormValidation.Base,
    t.fn.formValidation.DEFAULT_MESSAGE = "This value is not valid",
    t.fn.formValidation.DEFAULT_OPTIONS = {
        autoFocus: !0,
        declarative: !0,
        elementClass: "fv-form",
        events: {
            formInit: "init.form.fv",
            formPreValidate: "prevalidate.form.fv",
            formError: "err.form.fv",
            formSuccess: "success.form.fv",
            fieldAdded: "added.field.fv",
            fieldRemoved: "removed.field.fv",
            fieldInit: "init.field.fv",
            fieldError: "err.field.fv",
            fieldSuccess: "success.field.fv",
            fieldStatus: "status.field.fv",
            localeChanged: "changed.locale.fv",
            validatorError: "err.validator.fv",
            validatorSuccess: "success.validator.fv",
            validatorIgnored: "ignored.validator.fv"
        },
        excluded: [":disabled", ":hidden", ":not(:visible)"],
        fields: null,
        live: "enabled",
        locale: "en_US",
        message: null,
        threshold: null,
        verbose: !0,
        button: {
            selector: '[type="submit"]:not([formnovalidate])',
            disabled: ""
        },
        control: {
            valid: "",
            invalid: ""
        },
        err: {
            clazz: "",
            container: null,
            parent: null
        },
        icon: {
            valid: null,
            invalid: null,
            validating: null,
            feedback: ""
        },
        row: {
            selector: null,
            valid: "",
            invalid: "",
            feedback: ""
        }
    }
}
(jQuery),
function (t) {
    FormValidation.Helper = {
        call: function (t, e) {
            if ("function" == typeof t)
                return t.apply(this, e);
            if ("string" == typeof t) {
                "()" === t.substring(t.length - 2) && (t = t.substring(0, t.length - 2));
                for (var a = t.split("."), i = a.pop(), r = window, s = 0; s < a.length; s++)
                    r = r[a[s]];
                return "undefined" == typeof r[i] ? null : r[i].apply(this, e)
            }
        },
        date: function (t, e, a, i) {
            if (isNaN(t) || isNaN(e) || isNaN(a))
                return !1;
            if (a.length > 2 || e.length > 2 || t.length > 4)
                return !1;
            if (a = parseInt(a, 10),
            e = parseInt(e, 10),
            t = parseInt(t, 10),
            1e3 > t || t > 9999 || 0 >= e || e > 12)
                return !1;
            var r = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
            if ((t % 400 === 0 || t % 100 !== 0 && t % 4 === 0) && (r[1] = 29),
            0 >= a || a > r[e - 1])
                return !1;
            if (i === !0) {
                var s = new Date
                  , n = s.getFullYear()
                  , o = s.getMonth()
                  , l = s.getDate();
                return n > t || t === n && o > e - 1 || t === n && e - 1 === o && l > a
            }
            return !0
        },
        format: function (e, a) {
            t.isArray(a) || (a = [a]);
            for (var i in a)
                e = e.replace("%s", a[i]);
            return e
        },
        luhn: function (t) {
            for (var e = t.length, a = 0, i = [[0, 1, 2, 3, 4, 5, 6, 7, 8, 9], [0, 2, 4, 6, 8, 1, 3, 5, 7, 9]], r = 0; e--;)
                r += i[a][parseInt(t.charAt(e), 10)],
                a ^= 1;
            return r % 10 === 0 && r > 0
        },
        mod11And10: function (t) {
            for (var e = 5, a = t.length, i = 0; a > i; i++)
                e = (2 * (e || 10) % 11 + parseInt(t.charAt(i), 10)) % 10;
            return 1 === e
        },
        mod37And36: function (t, e) {
            e = e || "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (var a = e.length, i = t.length, r = Math.floor(a / 2), s = 0; i > s; s++)
                r = (2 * (r || a) % (a + 1) + e.indexOf(t.charAt(s))) % a;
            return 1 === r
        }
    }
}(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            base64: {
                "default": "Please enter a valid base 64 encoded"
            }
        }
    }),
    FormValidation.Validator.base64 = {
        validate: function (t, e, a, i) {
            var r = t.getFieldValue(e, i);
            return "" === r ? !0 : /^(?:[A-Za-z0-9+\/]{4})*(?:[A-Za-z0-9+\/]{2}==|[A-Za-z0-9+\/]{3}=|[A-Za-z0-9+\/]{4})$/.test(r)
        }
    }
}(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            between: {
                "default": "Please enter a value between %s and %s",
                notInclusive: "Please enter a value between %s and %s strictly"
            }
        }
    }),
    FormValidation.Validator.between = {
        html5Attributes: {
            message: "message",
            min: "min",
            max: "max",
            inclusive: "inclusive"
        },
        enableByHtml5: function (t) {
            return "range" === t.attr("type") ? {
                min: t.attr("min"),
                max: t.attr("max")
            } : !1
        },
        validate: function (e, a, i, r) {
            var s = e.getFieldValue(a, r);
            if ("" === s)
                return !0;
            s = this._format(s);
            var n = e.getLocale()
              , o = t.isNumeric(i.min) ? i.min : e.getDynamicOption(a, i.min)
              , l = t.isNumeric(i.max) ? i.max : e.getDynamicOption(a, i.max)
              , d = this._format(o)
              , u = this._format(l);
            return i.inclusive === !0 || void 0 === i.inclusive ? {
                valid: t.isNumeric(s) && parseFloat(s) >= d && parseFloat(s) <= u,
                message: FormValidation.Helper.format(i.message || FormValidation.I18n[n].between["default"], [o, l])
            } : {
                valid: t.isNumeric(s) && parseFloat(s) > d && parseFloat(s) < u,
                message: FormValidation.Helper.format(i.message || FormValidation.I18n[n].between.notInclusive, [o, l])
            }
        },
        _format: function (t) {
            return (t + "").replace(",", ".")
        }
    }
}
(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            bic: {
                "default": "Please enter a valid BIC number"
            }
        }
    }),
    FormValidation.Validator.bic = {
        validate: function (t, e, a, i) {
            var r = t.getFieldValue(e, i);
            return "" === r ? !0 : /^[a-zA-Z]{6}[a-zA-Z0-9]{2}([a-zA-Z0-9]{3})?$/.test(r)
        }
    }
}(jQuery),
function (t) {
    FormValidation.Validator.blank = {
        validate: function (t, e, a, i) {
            return !0
        }
    }
}(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            callback: {
                "default": "Please enter a valid value"
            }
        }
    }),
    FormValidation.Validator.callback = {
        html5Attributes: {
            message: "message",
            callback: "callback"
        },
        validate: function (e, a, i, r) {
            var s = e.getFieldValue(a, r)
              , n = new t.Deferred
              , o = {
                  valid: !0
              };
            if (i.callback) {
                var l = FormValidation.Helper.call(i.callback, [s, e, a]);
                o = "boolean" == typeof l || null === l ? {
                    valid: l
                } : l
            }
            return n.resolve(a, r, o),
            n
        }
    }
}
(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            choice: {
                "default": "Please enter a valid value",
                less: "Please choose %s options at minimum",
                more: "Please choose %s options at maximum",
                between: "Please choose %s - %s options"
            }
        }
    }),
    FormValidation.Validator.choice = {
        html5Attributes: {
            message: "message",
            min: "min",
            max: "max"
        },
        validate: function (e, a, i, r) {
            var s = e.getLocale()
              , n = e.getNamespace()
              , o = a.is("select") ? e.getFieldElements(a.attr("data-" + n + "-field")).find("option").filter(":selected").length : e.getFieldElements(a.attr("data-" + n + "-field")).filter(":checked").length
              , l = i.min ? t.isNumeric(i.min) ? i.min : e.getDynamicOption(a, i.min) : null
              , d = i.max ? t.isNumeric(i.max) ? i.max : e.getDynamicOption(a, i.max) : null
              , u = !0
              , f = i.message || FormValidation.I18n[s].choice["default"];
            switch ((l && o < parseInt(l, 10) || d && o > parseInt(d, 10)) && (u = !1),
            !0) {
                case !!l && !!d:
                    f = FormValidation.Helper.format(i.message || FormValidation.I18n[s].choice.between, [parseInt(l, 10), parseInt(d, 10)]);
                    break;
                case !!l:
                    f = FormValidation.Helper.format(i.message || FormValidation.I18n[s].choice.less, parseInt(l, 10));
                    break;
                case !!d:
                    f = FormValidation.Helper.format(i.message || FormValidation.I18n[s].choice.more, parseInt(d, 10))
            }
            return {
                valid: u,
                message: f
            }
        }
    }
}
(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            color: {
                "default": "Please enter a valid color"
            }
        }
    }),
    FormValidation.Validator.color = {
        html5Attributes: {
            message: "message",
            type: "type"
        },
        enableByHtml5: function (t) {
            return "color" === t.attr("type")
        },
        SUPPORTED_TYPES: ["hex", "rgb", "rgba", "hsl", "hsla", "keyword"],
        KEYWORD_COLORS: ["aliceblue", "antiquewhite", "aqua", "aquamarine", "azure", "beige", "bisque", "black", "blanchedalmond", "blue", "blueviolet", "brown", "burlywood", "cadetblue", "chartreuse", "chocolate", "coral", "cornflowerblue", "cornsilk", "crimson", "cyan", "darkblue", "darkcyan", "darkgoldenrod", "darkgray", "darkgreen", "darkgrey", "darkkhaki", "darkmagenta", "darkolivegreen", "darkorange", "darkorchid", "darkred", "darksalmon", "darkseagreen", "darkslateblue", "darkslategray", "darkslategrey", "darkturquoise", "darkviolet", "deeppink", "deepskyblue", "dimgray", "dimgrey", "dodgerblue", "firebrick", "floralwhite", "forestgreen", "fuchsia", "gainsboro", "ghostwhite", "gold", "goldenrod", "gray", "green", "greenyellow", "grey", "honeydew", "hotpink", "indianred", "indigo", "ivory", "khaki", "lavender", "lavenderblush", "lawngreen", "lemonchiffon", "lightblue", "lightcoral", "lightcyan", "lightgoldenrodyellow", "lightgray", "lightgreen", "lightgrey", "lightpink", "lightsalmon", "lightseagreen", "lightskyblue", "lightslategray", "lightslategrey", "lightsteelblue", "lightyellow", "lime", "limegreen", "linen", "magenta", "maroon", "mediumaquamarine", "mediumblue", "mediumorchid", "mediumpurple", "mediumseagreen", "mediumslateblue", "mediumspringgreen", "mediumturquoise", "mediumvioletred", "midnightblue", "mintcream", "mistyrose", "moccasin", "navajowhite", "navy", "oldlace", "olive", "olivedrab", "orange", "orangered", "orchid", "palegoldenrod", "palegreen", "paleturquoise", "palevioletred", "papayawhip", "peachpuff", "peru", "pink", "plum", "powderblue", "purple", "red", "rosybrown", "royalblue", "saddlebrown", "salmon", "sandybrown", "seagreen", "seashell", "sienna", "silver", "skyblue", "slateblue", "slategray", "slategrey", "snow", "springgreen", "steelblue", "tan", "teal", "thistle", "tomato", "transparent", "turquoise", "violet", "wheat", "white", "whitesmoke", "yellow", "yellowgreen"],
        validate: function (e, a, i, r) {
            var s = e.getFieldValue(a, r);
            if ("" === s)
                return !0;
            if (this.enableByHtml5(a))
                return /^#[0-9A-F]{6}$/i.test(s);
            var n = i.type || this.SUPPORTED_TYPES;
            t.isArray(n) || (n = n.replace(/s/g, "").split(","));
            for (var o, l, d = !1, u = 0; u < n.length; u++)
                if (l = n[u],
                o = "_" + l.toLowerCase(),
                d = d || this[o](s))
                    return !0;
            return !1
        },
        _hex: function (t) {
            return /(^#[0-9A-F]{6}$)|(^#[0-9A-F]{3}$)/i.test(t)
        },
        _hsl: function (t) {
            return /^hsl\((\s*(-?\d+)\s*,)(\s*(\b(0?\d{1,2}|100)\b%)\s*,)(\s*(\b(0?\d{1,2}|100)\b%)\s*)\)$/.test(t)
        },
        _hsla: function (t) {
            return /^hsla\((\s*(-?\d+)\s*,)(\s*(\b(0?\d{1,2}|100)\b%)\s*,){2}(\s*(0?(\.\d+)?|1(\.0+)?)\s*)\)$/.test(t)
        },
        _keyword: function (e) {
            return t.inArray(e, this.KEYWORD_COLORS) >= 0
        },
        _rgb: function (t) {
            var e = /^rgb\((\s*(\b([01]?\d{1,2}|2[0-4]\d|25[0-5])\b)\s*,){2}(\s*(\b([01]?\d{1,2}|2[0-4]\d|25[0-5])\b)\s*)\)$/
              , a = /^rgb\((\s*(\b(0?\d{1,2}|100)\b%)\s*,){2}(\s*(\b(0?\d{1,2}|100)\b%)\s*)\)$/;
            return e.test(t) || a.test(t)
        },
        _rgba: function (t) {
            var e = /^rgba\((\s*(\b([01]?\d{1,2}|2[0-4]\d|25[0-5])\b)\s*,){3}(\s*(0?(\.\d+)?|1(\.0+)?)\s*)\)$/
              , a = /^rgba\((\s*(\b(0?\d{1,2}|100)\b%)\s*,){3}(\s*(0?(\.\d+)?|1(\.0+)?)\s*)\)$/;
            return e.test(t) || a.test(t)
        }
    }
}
(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            creditCard: {
                "default": "Please enter a valid credit card number"
            }
        }
    }),
    FormValidation.Validator.creditCard = {
        validate: function (e, a, i, r) {
            var s = e.getFieldValue(a, r);
            if ("" === s)
                return !0;
            if (/[^0-9-\s]+/.test(s))
                return !1;
            if (s = s.replace(/\D/g, ""),
            !FormValidation.Helper.luhn(s))
                return !1;
            var n, o, l = {
                AMERICAN_EXPRESS: {
                    length: [15],
                    prefix: ["34", "37"]
                },
                DINERS_CLUB: {
                    length: [14],
                    prefix: ["300", "301", "302", "303", "304", "305", "36"]
                },
                DINERS_CLUB_US: {
                    length: [16],
                    prefix: ["54", "55"]
                },
                DISCOVER: {
                    length: [16],
                    prefix: ["6011", "622126", "622127", "622128", "622129", "62213", "62214", "62215", "62216", "62217", "62218", "62219", "6222", "6223", "6224", "6225", "6226", "6227", "6228", "62290", "62291", "622920", "622921", "622922", "622923", "622924", "622925", "644", "645", "646", "647", "648", "649", "65"]
                },
                JCB: {
                    length: [16],
                    prefix: ["3528", "3529", "353", "354", "355", "356", "357", "358"]
                },
                LASER: {
                    length: [16, 17, 18, 19],
                    prefix: ["6304", "6706", "6771", "6709"]
                },
                MAESTRO: {
                    length: [12, 13, 14, 15, 16, 17, 18, 19],
                    prefix: ["5018", "5020", "5038", "6304", "6759", "6761", "6762", "6763", "6764", "6765", "6766"]
                },
                MASTERCARD: {
                    length: [16],
                    prefix: ["51", "52", "53", "54", "55"]
                },
                SOLO: {
                    length: [16, 18, 19],
                    prefix: ["6334", "6767"]
                },
                UNIONPAY: {
                    length: [16, 17, 18, 19],
                    prefix: ["622126", "622127", "622128", "622129", "62213", "62214", "62215", "62216", "62217", "62218", "62219", "6222", "6223", "6224", "6225", "6226", "6227", "6228", "62290", "62291", "622920", "622921", "622922", "622923", "622924", "622925"]
                },
                VISA: {
                    length: [16],
                    prefix: ["4"]
                }
            };
            for (n in l)
                for (o in l[n].prefix)
                    if (s.substr(0, l[n].prefix[o].length) === l[n].prefix[o] && -1 !== t.inArray(s.length, l[n].length))
                        return {
                            valid: !0,
                            type: n
                        };
            return !1
        }
    }
}(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            cusip: {
                "default": "Please enter a valid CUSIP number"
            }
        }
    }),
    FormValidation.Validator.cusip = {
        validate: function (e, a, i, r) {
            var s = e.getFieldValue(a, r);
            if ("" === s)
                return !0;
            if (s = s.toUpperCase(),
            !/^[0-9A-Z]{9}$/.test(s))
                return !1;
            for (var n = t.map(s.split(""), function (t) {
                var e = t.charCodeAt(0);
                return e >= "A".charCodeAt(0) && e <= "Z".charCodeAt(0) ? e - "A".charCodeAt(0) + 10 : t
            }), o = n.length, l = 0, d = 0; o - 1 > d; d++) {
                var u = parseInt(n[d], 10);
                d % 2 !== 0 && (u *= 2),
                u > 9 && (u -= 9),
                l += u
            }
            return l = (10 - l % 10) % 10,
            l === parseInt(n[o - 1], 10)
        }
    }
}(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            cvv: {
                "default": "Please enter a valid CVV number"
            }
        }
    }),
    FormValidation.Validator.cvv = {
        html5Attributes: {
            message: "message",
            ccfield: "creditCardField"
        },
        init: function (t, e, a, i) {
            if (a.creditCardField) {
                var r = t.getFieldElements(a.creditCardField);
                t.onLiveChange(r, "live_" + i, function () {
                    var a = t.getStatus(e, i);
                    a !== t.STATUS_NOT_VALIDATED && t.revalidateField(e)
                })
            }
        },
        destroy: function (t, e, a, i) {
            if (a.creditCardField) {
                var r = t.getFieldElements(a.creditCardField);
                t.offLiveChange(r, "live_" + i)
            }
        },
        validate: function (e, a, i, r) {
            var s = e.getFieldValue(a, r);
            if ("" === s)
                return !0;
            if (!/^[0-9]{3,4}$/.test(s))
                return !1;
            if (!i.creditCardField)
                return !0;
            var n = e.getFieldElements(i.creditCardField).val();
            if ("" === n)
                return !0;
            n = n.replace(/\D/g, "");
            var o, l, d = {
                AMERICAN_EXPRESS: {
                    length: [15],
                    prefix: ["34", "37"]
                },
                DINERS_CLUB: {
                    length: [14],
                    prefix: ["300", "301", "302", "303", "304", "305", "36"]
                },
                DINERS_CLUB_US: {
                    length: [16],
                    prefix: ["54", "55"]
                },
                DISCOVER: {
                    length: [16],
                    prefix: ["6011", "622126", "622127", "622128", "622129", "62213", "62214", "62215", "62216", "62217", "62218", "62219", "6222", "6223", "6224", "6225", "6226", "6227", "6228", "62290", "62291", "622920", "622921", "622922", "622923", "622924", "622925", "644", "645", "646", "647", "648", "649", "65"]
                },
                JCB: {
                    length: [16],
                    prefix: ["3528", "3529", "353", "354", "355", "356", "357", "358"]
                },
                LASER: {
                    length: [16, 17, 18, 19],
                    prefix: ["6304", "6706", "6771", "6709"]
                },
                MAESTRO: {
                    length: [12, 13, 14, 15, 16, 17, 18, 19],
                    prefix: ["5018", "5020", "5038", "6304", "6759", "6761", "6762", "6763", "6764", "6765", "6766"]
                },
                MASTERCARD: {
                    length: [16],
                    prefix: ["51", "52", "53", "54", "55"]
                },
                SOLO: {
                    length: [16, 18, 19],
                    prefix: ["6334", "6767"]
                },
                UNIONPAY: {
                    length: [16, 17, 18, 19],
                    prefix: ["622126", "622127", "622128", "622129", "62213", "62214", "62215", "62216", "62217", "62218", "62219", "6222", "6223", "6224", "6225", "6226", "6227", "6228", "62290", "62291", "622920", "622921", "622922", "622923", "622924", "622925"]
                },
                VISA: {
                    length: [16],
                    prefix: ["4"]
                }
            }, u = null;
            for (o in d)
                for (l in d[o].prefix)
                    if (n.substr(0, d[o].prefix[l].length) === d[o].prefix[l] && -1 !== t.inArray(n.length, d[o].length)) {
                        u = o;
                        break
                    }
            return null === u ? !1 : "AMERICAN_EXPRESS" === u ? 4 === s.length : 3 === s.length
        }
    }
}
(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            date: {
                "default": "Please enter a valid date",
                min: "Please enter a date after %s",
                max: "Please enter a date before %s",
                range: "Please enter a date in the range %s - %s"
            }
        }
    }),
    FormValidation.Validator.date = {
        html5Attributes: {
            message: "message",
            format: "format",
            min: "min",
            max: "max",
            separator: "separator"
        },
        validate: function (e, a, i, r) {
            var s = e.getFieldValue(a, r);
            if ("" === s)
                return !0;
            i.format = i.format || "MM/DD/YYYY",
            "date" === a.attr("type") && (i.format = "YYYY-MM-DD");
            var n = e.getLocale()
              , o = i.message || FormValidation.I18n[n].date["default"]
              , l = i.format.split(" ")
              , d = l[0]
              , u = l.length > 1 ? l[1] : null
              , f = l.length > 2 ? l[2] : null
              , c = s.split(" ")
              , h = c[0]
              , p = c.length > 1 ? c[1] : null;
            if (l.length !== c.length)
                return {
                    valid: !1,
                    message: o
                };
            var m = i.separator;
            if (m || (m = -1 !== h.indexOf("/") ? "/" : -1 !== h.indexOf("-") ? "-" : -1 !== h.indexOf(".") ? "." : null),
            null === m || -1 === h.indexOf(m))
                return {
                    valid: !1,
                    message: o
                };
            if (h = h.split(m),
            d = d.split(m),
            h.length !== d.length)
                return {
                    valid: !1,
                    message: o
                };
            var v = h[t.inArray("YYYY", d)]
              , g = h[t.inArray("MM", d)]
              , A = h[t.inArray("DD", d)];
            if (!v || !g || !A || 4 !== v.length)
                return {
                    valid: !1,
                    message: o
                };
            var I = null
              , b = null
              , F = null;
            if (u) {
                if (u = u.split(":"),
                p = p.split(":"),
                u.length !== p.length)
                    return {
                        valid: !1,
                        message: o
                    };
                if (b = p.length > 0 ? p[0] : null,
                I = p.length > 1 ? p[1] : null,
                F = p.length > 2 ? p[2] : null,
                "" === b || "" === I || "" === F)
                    return {
                        valid: !1,
                        message: o
                    };
                if (F) {
                    if (isNaN(F) || F.length > 2)
                        return {
                            valid: !1,
                            message: o
                        };
                    if (F = parseInt(F, 10),
                    0 > F || F > 60)
                        return {
                            valid: !1,
                            message: o
                        }
                }
                if (b) {
                    if (isNaN(b) || b.length > 2)
                        return {
                            valid: !1,
                            message: o
                        };
                    if (b = parseInt(b, 10),
                    0 > b || b >= 24 || f && b > 12)
                        return {
                            valid: !1,
                            message: o
                        }
                }
                if (I) {
                    if (isNaN(I) || I.length > 2)
                        return {
                            valid: !1,
                            message: o
                        };
                    if (I = parseInt(I, 10),
                    0 > I || I > 59)
                        return {
                            valid: !1,
                            message: o
                        }
                }
            }
            var V = FormValidation.Helper.date(v, g, A)
              , S = null
              , T = null
              , E = i.min
              , _ = i.max;
            switch (E && (isNaN(Date.parse(E)) && (E = e.getDynamicOption(a, E)),
            S = E instanceof Date ? E : this._parseDate(E, d, m),
            E = E instanceof Date ? this._formatDate(E, i.format) : E),
            _ && (isNaN(Date.parse(_)) && (_ = e.getDynamicOption(a, _)),
            T = _ instanceof Date ? _ : this._parseDate(_, d, m),
            _ = _ instanceof Date ? this._formatDate(_, i.format) : _),
            h = new Date(v, g - 1, A, b, I, F),
            !0) {
                case E && !_ && V:
                    V = h.getTime() >= S.getTime(),
                    o = i.message || FormValidation.Helper.format(FormValidation.I18n[n].date.min, E);
                    break;
                case _ && !E && V:
                    V = h.getTime() <= T.getTime(),
                    o = i.message || FormValidation.Helper.format(FormValidation.I18n[n].date.max, _);
                    break;
                case _ && E && V:
                    V = h.getTime() <= T.getTime() && h.getTime() >= S.getTime(),
                    o = i.message || FormValidation.Helper.format(FormValidation.I18n[n].date.range, [E, _])
            }
            return {
                valid: V,
                date: h,
                message: o
            }
        },
        _parseDate: function (e, a, i) {
            var r = 0
              , s = 0
              , n = 0
              , o = e.split(" ")
              , l = o[0]
              , d = o.length > 1 ? o[1] : null;
            l = l.split(i);
            var u = l[t.inArray("YYYY", a)]
              , f = l[t.inArray("MM", a)]
              , c = l[t.inArray("DD", a)];
            return d && (d = d.split(":"),
            s = d.length > 0 ? d[0] : null,
            r = d.length > 1 ? d[1] : null,
            n = d.length > 2 ? d[2] : null),
            new Date(u, f - 1, c, s, r, n)
        },
        _formatDate: function (t, e) {
            e = e.replace(/Y/g, "y").replace(/M/g, "m").replace(/D/g, "d").replace(/:m/g, ":M").replace(/:mm/g, ":MM").replace(/:S/, ":s").replace(/:SS/, ":ss");
            var a = {
                d: function (t) {
                    return t.getDate()
                },
                dd: function (t) {
                    var e = t.getDate();
                    return 10 > e ? "0" + e : e
                },
                m: function (t) {
                    return t.getMonth() + 1
                },
                mm: function (t) {
                    var e = t.getMonth() + 1;
                    return 10 > e ? "0" + e : e
                },
                yy: function (t) {
                    return ("" + t.getFullYear()).substr(2)
                },
                yyyy: function (t) {
                    return t.getFullYear()
                },
                h: function (t) {
                    return t.getHours() % 12 || 12
                },
                hh: function (t) {
                    var e = t.getHours() % 12 || 12;
                    return 10 > e ? "0" + e : e
                },
                H: function (t) {
                    return t.getHours()
                },
                HH: function (t) {
                    var e = t.getHours();
                    return 10 > e ? "0" + e : e
                },
                M: function (t) {
                    return t.getMinutes()
                },
                MM: function (t) {
                    var e = t.getMinutes();
                    return 10 > e ? "0" + e : e
                },
                s: function (t) {
                    return t.getSeconds()
                },
                ss: function (t) {
                    var e = t.getSeconds();
                    return 10 > e ? "0" + e : e
                }
            };
            return e.replace(/d{1,4}|m{1,4}|yy(?:yy)?|([HhMs])\1?|"[^"]*"|'[^']*'/g, function (e) {
                return a[e] ? a[e](t) : e.slice(1, e.length - 1)
            })
        }
    }
}
(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            different: {
                "default": "Please enter a different value"
            }
        }
    }),
    FormValidation.Validator.different = {
        html5Attributes: {
            message: "message",
            field: "field"
        },
        init: function (t, e, a, i) {
            for (var r = a.field.split(","), s = 0; s < r.length; s++) {
                var n = t.getFieldElements(r[s]);
                t.onLiveChange(n, "live_" + i, function () {
                    var a = t.getStatus(e, i);
                    a !== t.STATUS_NOT_VALIDATED && t.revalidateField(e)
                })
            }
        },
        destroy: function (t, e, a, i) {
            for (var r = a.field.split(","), s = 0; s < r.length; s++) {
                var n = t.getFieldElements(r[s]);
                t.offLiveChange(n, "live_" + i)
            }
        },
        validate: function (t, e, a, i) {
            var r = t.getFieldValue(e, i);
            if ("" === r)
                return !0;
            for (var s = a.field.split(","), n = !0, o = 0; o < s.length; o++) {
                var l = t.getFieldElements(s[o]);
                if (null != l && 0 !== l.length) {
                    var d = t.getFieldValue(l, i);
                    r === d ? n = !1 : "" !== d && t.updateStatus(l, t.STATUS_VALID, i)
                }
            }
            return n
        }
    }
}
(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            digits: {
                "default": "Please enter only digits"
            }
        }
    }),
    FormValidation.Validator.digits = {
        validate: function (t, e, a, i) {
            var r = t.getFieldValue(e, i);
            return "" === r ? !0 : /^\d+$/.test(r)
        }
    }
}(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            ean: {
                "default": "Please enter a valid EAN number"
            }
        }
    }),
    FormValidation.Validator.ean = {
        validate: function (t, e, a, i) {
            var r = t.getFieldValue(e, i);
            if ("" === r)
                return !0;
            if (!/^(\d{8}|\d{12}|\d{13})$/.test(r))
                return !1;
            for (var s = r.length, n = 0, o = 8 === s ? [3, 1] : [1, 3], l = 0; s - 1 > l; l++)
                n += parseInt(r.charAt(l), 10) * o[l % 2];
            return n = (10 - n % 10) % 10,
            n + "" === r.charAt(s - 1)
        }
    }
}(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            ein: {
                "default": "Please enter a valid EIN number"
            }
        }
    }),
    FormValidation.Validator.ein = {
        CAMPUS: {
            ANDOVER: ["10", "12"],
            ATLANTA: ["60", "67"],
            AUSTIN: ["50", "53"],
            BROOKHAVEN: ["01", "02", "03", "04", "05", "06", "11", "13", "14", "16", "21", "22", "23", "25", "34", "51", "52", "54", "55", "56", "57", "58", "59", "65"],
            CINCINNATI: ["30", "32", "35", "36", "37", "38", "61"],
            FRESNO: ["15", "24"],
            KANSAS_CITY: ["40", "44"],
            MEMPHIS: ["94", "95"],
            OGDEN: ["80", "90"],
            PHILADELPHIA: ["33", "39", "41", "42", "43", "46", "48", "62", "63", "64", "66", "68", "71", "72", "73", "74", "75", "76", "77", "81", "82", "83", "84", "85", "86", "87", "88", "91", "92", "93", "98", "99"],
            INTERNET: ["20", "26", "27", "45", "46"],
            SMALL_BUSINESS_ADMINISTRATION: ["31"]
        },
        validate: function (e, a, i, r) {
            var s = e.getFieldValue(a, r);
            if ("" === s)
                return !0;
            if (!/^[0-9]{2}-?[0-9]{7}$/.test(s))
                return !1;
            var n = s.substr(0, 2) + "";
            for (var o in this.CAMPUS)
                if (-1 !== t.inArray(n, this.CAMPUS[o]))
                    return {
                        valid: !0,
                        campus: o
                    };
            return !1
        }
    }
}(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            emailAddress: {
                "default": "Please enter a valid email address"
            }
        }
    }),
    FormValidation.Validator.emailAddress = {
        html5Attributes: {
            message: "message",
            multiple: "multiple",
            separator: "separator"
        },
        enableByHtml5: function (t) {
            return "email" === t.attr("type")
        },
        validate: function (t, e, a, i) {
            var r = t.getFieldValue(e, i);
            if ("" === r)
                return !0;
            var s = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/
              , n = a.multiple === !0 || "true" === a.multiple;
            if (n) {
                for (var o = a.separator || /[,;]/, l = this._splitEmailAddresses(r, o), d = 0; d < l.length; d++)
                    if (!s.test(l[d]))
                        return !1;
                return !0
            }
            return s.test(r)
        },
        _splitEmailAddresses: function (t, e) {
            for (var a = t.split(/"/), i = a.length, r = [], s = "", n = 0; i > n; n++)
                if (n % 2 === 0) {
                    var o = a[n].split(e)
                      , l = o.length;
                    if (1 === l)
                        s += o[0];
                    else {
                        r.push(s + o[0]);
                        for (var d = 1; l - 1 > d; d++)
                            r.push(o[d]);
                        s = o[l - 1]
                    }
                } else
                    s += '"' + a[n],
                    i - 1 > n && (s += '"');
            return r.push(s),
            r
        }
    }
}
(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            file: {
                "default": "Please choose a valid file"
            }
        }
    }),
    FormValidation.Validator.file = {
        html5Attributes: {
            extension: "extension",
            maxfiles: "maxFiles",
            minfiles: "minFiles",
            maxsize: "maxSize",
            minsize: "minSize",
            maxtotalsize: "maxTotalSize",
            mintotalsize: "minTotalSize",
            message: "message",
            type: "type"
        },
        validate: function (e, a, i, r) {
            var s = e.getFieldValue(a, r);
            if ("" === s)
                return !0;
            var n, o = i.extension ? i.extension.toLowerCase().split(",") : null, l = i.type ? i.type.toLowerCase().split(",") : null, d = window.File && window.FileList && window.FileReader;
            if (d) {
                var u = a.get(0).files
                  , f = u.length
                  , c = 0;
                if (i.maxFiles && f > parseInt(i.maxFiles, 10) || i.minFiles && f < parseInt(i.minFiles, 10))
                    return !1;
                for (var h = 0; f > h; h++)
                    if (c += u[h].size,
                    n = u[h].name.substr(u[h].name.lastIndexOf(".") + 1),
                    i.minSize && u[h].size < parseInt(i.minSize, 10) || i.maxSize && u[h].size > parseInt(i.maxSize, 10) || o && -1 === t.inArray(n.toLowerCase(), o) || u[h].type && l && -1 === t.inArray(u[h].type.toLowerCase(), l))
                        return !1;
                if (i.maxTotalSize && c > parseInt(i.maxTotalSize, 10) || i.minTotalSize && c < parseInt(i.minTotalSize, 10))
                    return !1
            } else if (n = s.substr(s.lastIndexOf(".") + 1),
            o && -1 === t.inArray(n.toLowerCase(), o))
                return !1;
            return !0
        }
    }
}
(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            greaterThan: {
                "default": "Please enter a value greater than or equal to %s",
                notInclusive: "Please enter a value greater than %s"
            }
        }
    }),
    FormValidation.Validator.greaterThan = {
        html5Attributes: {
            message: "message",
            value: "value",
            inclusive: "inclusive"
        },
        enableByHtml5: function (t) {
            var e = t.attr("type")
              , a = t.attr("min");
            return a && "date" !== e ? {
                value: a
            } : !1
        },
        validate: function (e, a, i, r) {
            var s = e.getFieldValue(a, r);
            if ("" === s)
                return !0;
            s = this._format(s);
            var n = e.getLocale()
              , o = t.isNumeric(i.value) ? i.value : e.getDynamicOption(a, i.value)
              , l = this._format(o);
            return i.inclusive === !0 || void 0 === i.inclusive ? {
                valid: t.isNumeric(s) && parseFloat(s) >= l,
                message: FormValidation.Helper.format(i.message || FormValidation.I18n[n].greaterThan["default"], o)
            } : {
                valid: t.isNumeric(s) && parseFloat(s) > l,
                message: FormValidation.Helper.format(i.message || FormValidation.I18n[n].greaterThan.notInclusive, o)
            }
        },
        _format: function (t) {
            return (t + "").replace(",", ".")
        }
    }
}
(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            grid: {
                "default": "Please enter a valid GRId number"
            }
        }
    }),
    FormValidation.Validator.grid = {
        validate: function (t, e, a, i) {
            var r = t.getFieldValue(e, i);
            return "" === r ? !0 : (r = r.toUpperCase(),
            /^[GRID:]*([0-9A-Z]{2})[-\s]*([0-9A-Z]{5})[-\s]*([0-9A-Z]{10})[-\s]*([0-9A-Z]{1})$/g.test(r) ? (r = r.replace(/\s/g, "").replace(/-/g, ""),
            "GRID:" === r.substr(0, 5) && (r = r.substr(5)),
            FormValidation.Helper.mod37And36(r)) : !1)
        }
    }
}(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            hex: {
                "default": "Please enter a valid hexadecimal number"
            }
        }
    }),
    FormValidation.Validator.hex = {
        validate: function (t, e, a, i) {
            var r = t.getFieldValue(e, i);
            return "" === r ? !0 : /^[0-9a-fA-F]+$/.test(r)
        }
    }
}(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            iban: {
                "default": "Please enter a valid IBAN number",
                country: "Please enter a valid IBAN number in %s",
                countries: {
                    AD: "Andorra",
                    AE: "United Arab Emirates",
                    AL: "Albania",
                    AO: "Angola",
                    AT: "Austria",
                    AZ: "Azerbaijan",
                    BA: "Bosnia and Herzegovina",
                    BE: "Belgium",
                    BF: "Burkina Faso",
                    BG: "Bulgaria",
                    BH: "Bahrain",
                    BI: "Burundi",
                    BJ: "Benin",
                    BR: "Brazil",
                    CH: "Switzerland",
                    CI: "Ivory Coast",
                    CM: "Cameroon",
                    CR: "Costa Rica",
                    CV: "Cape Verde",
                    CY: "Cyprus",
                    CZ: "Czech Republic",
                    DE: "Germany",
                    DK: "Denmark",
                    DO: "Dominican Republic",
                    DZ: "Algeria",
                    EE: "Estonia",
                    ES: "Spain",
                    FI: "Finland",
                    FO: "Faroe Islands",
                    FR: "France",
                    GB: "United Kingdom",
                    GE: "Georgia",
                    GI: "Gibraltar",
                    GL: "Greenland",
                    GR: "Greece",
                    GT: "Guatemala",
                    HR: "Croatia",
                    HU: "Hungary",
                    IE: "Ireland",
                    IL: "Israel",
                    IR: "Iran",
                    IS: "Iceland",
                    IT: "Italy",
                    JO: "Jordan",
                    KW: "Kuwait",
                    KZ: "Kazakhstan",
                    LB: "Lebanon",
                    LI: "Liechtenstein",
                    LT: "Lithuania",
                    LU: "Luxembourg",
                    LV: "Latvia",
                    MC: "Monaco",
                    MD: "Moldova",
                    ME: "Montenegro",
                    MG: "Madagascar",
                    MK: "Macedonia",
                    ML: "Mali",
                    MR: "Mauritania",
                    MT: "Malta",
                    MU: "Mauritius",
                    MZ: "Mozambique",
                    NL: "Netherlands",
                    NO: "Norway",
                    PK: "Pakistan",
                    PL: "Poland",
                    PS: "Palestine",
                    PT: "Portugal",
                    QA: "Qatar",
                    RO: "Romania",
                    RS: "Serbia",
                    SA: "Saudi Arabia",
                    SE: "Sweden",
                    SI: "Slovenia",
                    SK: "Slovakia",
                    SM: "San Marino",
                    SN: "Senegal",
                    TL: "East Timor",
                    TN: "Tunisia",
                    TR: "Turkey",
                    VG: "Virgin Islands, British",
                    XK: "Republic of Kosovo"
                }
            }
        }
    }),
    FormValidation.Validator.iban = {
        html5Attributes: {
            message: "message",
            country: "country",
            sepa: "sepa"
        },
        REGEX: {
            AD: "AD[0-9]{2}[0-9]{4}[0-9]{4}[A-Z0-9]{12}",
            AE: "AE[0-9]{2}[0-9]{3}[0-9]{16}",
            AL: "AL[0-9]{2}[0-9]{8}[A-Z0-9]{16}",
            AO: "AO[0-9]{2}[0-9]{21}",
            AT: "AT[0-9]{2}[0-9]{5}[0-9]{11}",
            AZ: "AZ[0-9]{2}[A-Z]{4}[A-Z0-9]{20}",
            BA: "BA[0-9]{2}[0-9]{3}[0-9]{3}[0-9]{8}[0-9]{2}",
            BE: "BE[0-9]{2}[0-9]{3}[0-9]{7}[0-9]{2}",
            BF: "BF[0-9]{2}[0-9]{23}",
            BG: "BG[0-9]{2}[A-Z]{4}[0-9]{4}[0-9]{2}[A-Z0-9]{8}",
            BH: "BH[0-9]{2}[A-Z]{4}[A-Z0-9]{14}",
            BI: "BI[0-9]{2}[0-9]{12}",
            BJ: "BJ[0-9]{2}[A-Z]{1}[0-9]{23}",
            BR: "BR[0-9]{2}[0-9]{8}[0-9]{5}[0-9]{10}[A-Z][A-Z0-9]",
            CH: "CH[0-9]{2}[0-9]{5}[A-Z0-9]{12}",
            CI: "CI[0-9]{2}[A-Z]{1}[0-9]{23}",
            CM: "CM[0-9]{2}[0-9]{23}",
            CR: "CR[0-9]{2}[0-9]{3}[0-9]{14}",
            CV: "CV[0-9]{2}[0-9]{21}",
            CY: "CY[0-9]{2}[0-9]{3}[0-9]{5}[A-Z0-9]{16}",
            CZ: "CZ[0-9]{2}[0-9]{20}",
            DE: "DE[0-9]{2}[0-9]{8}[0-9]{10}",
            DK: "DK[0-9]{2}[0-9]{14}",
            DO: "DO[0-9]{2}[A-Z0-9]{4}[0-9]{20}",
            DZ: "DZ[0-9]{2}[0-9]{20}",
            EE: "EE[0-9]{2}[0-9]{2}[0-9]{2}[0-9]{11}[0-9]{1}",
            ES: "ES[0-9]{2}[0-9]{4}[0-9]{4}[0-9]{1}[0-9]{1}[0-9]{10}",
            FI: "FI[0-9]{2}[0-9]{6}[0-9]{7}[0-9]{1}",
            FO: "FO[0-9]{2}[0-9]{4}[0-9]{9}[0-9]{1}",
            FR: "FR[0-9]{2}[0-9]{5}[0-9]{5}[A-Z0-9]{11}[0-9]{2}",
            GB: "GB[0-9]{2}[A-Z]{4}[0-9]{6}[0-9]{8}",
            GE: "GE[0-9]{2}[A-Z]{2}[0-9]{16}",
            GI: "GI[0-9]{2}[A-Z]{4}[A-Z0-9]{15}",
            GL: "GL[0-9]{2}[0-9]{4}[0-9]{9}[0-9]{1}",
            GR: "GR[0-9]{2}[0-9]{3}[0-9]{4}[A-Z0-9]{16}",
            GT: "GT[0-9]{2}[A-Z0-9]{4}[A-Z0-9]{20}",
            HR: "HR[0-9]{2}[0-9]{7}[0-9]{10}",
            HU: "HU[0-9]{2}[0-9]{3}[0-9]{4}[0-9]{1}[0-9]{15}[0-9]{1}",
            IE: "IE[0-9]{2}[A-Z]{4}[0-9]{6}[0-9]{8}",
            IL: "IL[0-9]{2}[0-9]{3}[0-9]{3}[0-9]{13}",
            IR: "IR[0-9]{2}[0-9]{22}",
            IS: "IS[0-9]{2}[0-9]{4}[0-9]{2}[0-9]{6}[0-9]{10}",
            IT: "IT[0-9]{2}[A-Z]{1}[0-9]{5}[0-9]{5}[A-Z0-9]{12}",
            JO: "JO[0-9]{2}[A-Z]{4}[0-9]{4}[0]{8}[A-Z0-9]{10}",
            KW: "KW[0-9]{2}[A-Z]{4}[0-9]{22}",
            KZ: "KZ[0-9]{2}[0-9]{3}[A-Z0-9]{13}",
            LB: "LB[0-9]{2}[0-9]{4}[A-Z0-9]{20}",
            LI: "LI[0-9]{2}[0-9]{5}[A-Z0-9]{12}",
            LT: "LT[0-9]{2}[0-9]{5}[0-9]{11}",
            LU: "LU[0-9]{2}[0-9]{3}[A-Z0-9]{13}",
            LV: "LV[0-9]{2}[A-Z]{4}[A-Z0-9]{13}",
            MC: "MC[0-9]{2}[0-9]{5}[0-9]{5}[A-Z0-9]{11}[0-9]{2}",
            MD: "MD[0-9]{2}[A-Z0-9]{20}",
            ME: "ME[0-9]{2}[0-9]{3}[0-9]{13}[0-9]{2}",
            MG: "MG[0-9]{2}[0-9]{23}",
            MK: "MK[0-9]{2}[0-9]{3}[A-Z0-9]{10}[0-9]{2}",
            ML: "ML[0-9]{2}[A-Z]{1}[0-9]{23}",
            MR: "MR13[0-9]{5}[0-9]{5}[0-9]{11}[0-9]{2}",
            MT: "MT[0-9]{2}[A-Z]{4}[0-9]{5}[A-Z0-9]{18}",
            MU: "MU[0-9]{2}[A-Z]{4}[0-9]{2}[0-9]{2}[0-9]{12}[0-9]{3}[A-Z]{3}",
            MZ: "MZ[0-9]{2}[0-9]{21}",
            NL: "NL[0-9]{2}[A-Z]{4}[0-9]{10}",
            NO: "NO[0-9]{2}[0-9]{4}[0-9]{6}[0-9]{1}",
            PK: "PK[0-9]{2}[A-Z]{4}[A-Z0-9]{16}",
            PL: "PL[0-9]{2}[0-9]{8}[0-9]{16}",
            PS: "PS[0-9]{2}[A-Z]{4}[A-Z0-9]{21}",
            PT: "PT[0-9]{2}[0-9]{4}[0-9]{4}[0-9]{11}[0-9]{2}",
            QA: "QA[0-9]{2}[A-Z]{4}[A-Z0-9]{21}",
            RO: "RO[0-9]{2}[A-Z]{4}[A-Z0-9]{16}",
            RS: "RS[0-9]{2}[0-9]{3}[0-9]{13}[0-9]{2}",
            SA: "SA[0-9]{2}[0-9]{2}[A-Z0-9]{18}",
            SE: "SE[0-9]{2}[0-9]{3}[0-9]{16}[0-9]{1}",
            SI: "SI[0-9]{2}[0-9]{5}[0-9]{8}[0-9]{2}",
            SK: "SK[0-9]{2}[0-9]{4}[0-9]{6}[0-9]{10}",
            SM: "SM[0-9]{2}[A-Z]{1}[0-9]{5}[0-9]{5}[A-Z0-9]{12}",
            SN: "SN[0-9]{2}[A-Z]{1}[0-9]{23}",
            TL: "TL38[0-9]{3}[0-9]{14}[0-9]{2}",
            TN: "TN59[0-9]{2}[0-9]{3}[0-9]{13}[0-9]{2}",
            TR: "TR[0-9]{2}[0-9]{5}[A-Z0-9]{1}[A-Z0-9]{16}",
            VG: "VG[0-9]{2}[A-Z]{4}[0-9]{16}",
            XK: "XK[0-9]{2}[0-9]{4}[0-9]{10}[0-9]{2}"
        },
        SEPA_COUNTRIES: ["AT", "BE", "BG", "CH", "CY", "CZ", "DE", "DK", "EE", "ES", "FI", "FR", "GB", "GI", "GR", "HR", "HU", "IE", "IS", "IT", "LI", "LT", "LU", "LV", "MC", "MT", "NL", "NO", "PL", "PT", "RO", "SE", "SI", "SK", "SM"],
        validate: function (e, a, i, r) {
            var s = e.getFieldValue(a, r);
            if ("" === s)
                return !0;
            s = s.replace(/[^a-zA-Z0-9]/g, "").toUpperCase();
            var n = i.country;
            n ? "string" == typeof n && this.REGEX[n] || (n = e.getDynamicOption(a, n)) : n = s.substr(0, 2);
            var o = e.getLocale();
            if (!this.REGEX[n])
                return !1;
            if (void 0 !== typeof i.sepa) {
                var l = -1 !== t.inArray(n, this.SEPA_COUNTRIES);
                if (("true" === i.sepa || i.sepa === !0) && !l || ("false" === i.sepa || i.sepa === !1) && l)
                    return !1
            }
            if (!new RegExp("^" + this.REGEX[n] + "$").test(s))
                return {
                    valid: !1,
                    message: FormValidation.Helper.format(i.message || FormValidation.I18n[o].iban.country, FormValidation.I18n[o].iban.countries[n])
                };
            s = s.substr(4) + s.substr(0, 4),
            s = t.map(s.split(""), function (t) {
                var e = t.charCodeAt(0);
                return e >= "A".charCodeAt(0) && e <= "Z".charCodeAt(0) ? e - "A".charCodeAt(0) + 10 : t
            }),
            s = s.join("");
            for (var d = parseInt(s.substr(0, 1), 10), u = s.length, f = 1; u > f; ++f)
                d = (10 * d + parseInt(s.substr(f, 1), 10)) % 97;
            return {
                valid: 1 === d,
                message: FormValidation.Helper.format(i.message || FormValidation.I18n[o].iban.country, FormValidation.I18n[o].iban.countries[n])
            }
        }
    }
}
(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            id: {
                "default": "Please enter a valid identification number",
                country: "Please enter a valid identification number in %s",
                countries: {
                    BA: "Bosnia and Herzegovina",
                    BG: "Bulgaria",
                    BR: "Brazil",
                    CH: "Switzerland",
                    CL: "Chile",
                    CN: "China",
                    CZ: "Czech Republic",
                    DK: "Denmark",
                    EE: "Estonia",
                    ES: "Spain",
                    FI: "Finland",
                    HR: "Croatia",
                    IE: "Ireland",
                    IS: "Iceland",
                    LT: "Lithuania",
                    LV: "Latvia",
                    ME: "Montenegro",
                    MK: "Macedonia",
                    NL: "Netherlands",
                    PL: "Poland",
                    RO: "Romania",
                    RS: "Serbia",
                    SE: "Sweden",
                    SI: "Slovenia",
                    SK: "Slovakia",
                    SM: "San Marino",
                    TH: "Thailand",
                    ZA: "South Africa"
                }
            }
        }
    }),
    FormValidation.Validator.id = {
        html5Attributes: {
            message: "message",
            country: "country"
        },
        COUNTRY_CODES: ["BA", "BG", "BR", "CH", "CL", "CN", "CZ", "DK", "EE", "ES", "FI", "HR", "IE", "IS", "LT", "LV", "ME", "MK", "NL", "PL", "RO", "RS", "SE", "SI", "SK", "SM", "TH", "ZA"],
        validate: function (e, a, i, r) {
            var s = e.getFieldValue(a, r);
            if ("" === s)
                return !0;
            var n = e.getLocale()
              , o = i.country;
            if (o ? ("string" != typeof o || -1 === t.inArray(o.toUpperCase(), this.COUNTRY_CODES)) && (o = e.getDynamicOption(a, o)) : o = s.substr(0, 2),
            -1 === t.inArray(o, this.COUNTRY_CODES))
                return !0;
            var l = ["_", o.toLowerCase()].join("")
              , d = this[l](s);
            return d = d === !0 || d === !1 ? {
                valid: d
            } : d,
            d.message = FormValidation.Helper.format(i.message || FormValidation.I18n[n].id.country, FormValidation.I18n[n].id.countries[o.toUpperCase()]),
            d
        },
        _validateJMBG: function (t, e) {
            if (!/^\d{13}$/.test(t))
                return !1;
            var a = parseInt(t.substr(0, 2), 10)
              , i = parseInt(t.substr(2, 2), 10)
              , r = (parseInt(t.substr(4, 3), 10),
            parseInt(t.substr(7, 2), 10))
              , s = parseInt(t.substr(12, 1), 10);
            if (a > 31 || i > 12)
                return !1;
            for (var n = 0, o = 0; 6 > o; o++)
                n += (7 - o) * (parseInt(t.charAt(o), 10) + parseInt(t.charAt(o + 6), 10));
            if (n = 11 - n % 11,
            (10 === n || 11 === n) && (n = 0),
            n !== s)
                return !1;
            switch (e.toUpperCase()) {
                case "BA":
                    return r >= 10 && 19 >= r;
                case "MK":
                    return r >= 41 && 49 >= r;
                case "ME":
                    return r >= 20 && 29 >= r;
                case "RS":
                    return r >= 70 && 99 >= r;
                case "SI":
                    return r >= 50 && 59 >= r;
                default:
                    return !0
            }
        },
        _ba: function (t) {
            return this._validateJMBG(t, "BA")
        },
        _mk: function (t) {
            return this._validateJMBG(t, "MK")
        },
        _me: function (t) {
            return this._validateJMBG(t, "ME")
        },
        _rs: function (t) {
            return this._validateJMBG(t, "RS")
        },
        _si: function (t) {
            return this._validateJMBG(t, "SI")
        },
        _bg: function (t) {
            if (!/^\d{10}$/.test(t) && !/^\d{6}\s\d{3}\s\d{1}$/.test(t))
                return !1;
            t = t.replace(/\s/g, "");
            var e = parseInt(t.substr(0, 2), 10) + 1900
              , a = parseInt(t.substr(2, 2), 10)
              , i = parseInt(t.substr(4, 2), 10);
            if (a > 40 ? (e += 100,
            a -= 40) : a > 20 && (e -= 100,
            a -= 20),
            !FormValidation.Helper.date(e, a, i))
                return !1;
            for (var r = 0, s = [2, 4, 8, 5, 10, 9, 7, 3, 6], n = 0; 9 > n; n++)
                r += parseInt(t.charAt(n), 10) * s[n];
            return r = r % 11 % 10,
            r + "" === t.substr(9, 1)
        },
        _br: function (t) {
            if (t = t.replace(/\D/g, ""),
            !/^\d{11}$/.test(t) || /^1{11}|2{11}|3{11}|4{11}|5{11}|6{11}|7{11}|8{11}|9{11}|0{11}$/.test(t))
                return !1;
            for (var e = 0, a = 0; 9 > a; a++)
                e += (10 - a) * parseInt(t.charAt(a), 10);
            if (e = 11 - e % 11,
            (10 === e || 11 === e) && (e = 0),
            e + "" !== t.charAt(9))
                return !1;
            var i = 0;
            for (a = 0; 10 > a; a++)
                i += (11 - a) * parseInt(t.charAt(a), 10);
            return i = 11 - i % 11,
            (10 === i || 11 === i) && (i = 0),
            i + "" === t.charAt(10)
        },
        _ch: function (t) {
            if (!/^756[\.]{0,1}[0-9]{4}[\.]{0,1}[0-9]{4}[\.]{0,1}[0-9]{2}$/.test(t))
                return !1;
            t = t.replace(/\D/g, "").substr(3);
            for (var e = t.length, a = 0, i = 8 === e ? [3, 1] : [1, 3], r = 0; e - 1 > r; r++)
                a += parseInt(t.charAt(r), 10) * i[r % 2];
            return a = 10 - a % 10,
            a + "" === t.charAt(e - 1)
        },
        _cl: function (t) {
            if (!/^\d{7,8}[-]{0,1}[0-9K]$/i.test(t))
                return !1;
            for (t = t.replace(/\-/g, "") ; t.length < 9;)
                t = "0" + t;
            for (var e = 0, a = [3, 2, 7, 6, 5, 4, 3, 2], i = 0; 8 > i; i++)
                e += parseInt(t.charAt(i), 10) * a[i];
            return e = 11 - e % 11,
            11 === e ? e = 0 : 10 === e && (e = "K"),
            e + "" === t.charAt(8).toUpperCase()
        },
        _cn: function (e) {
            if (e = e.trim(),
            !/^\d{15}$/.test(e) && !/^\d{17}[\dXx]{1}$/.test(e))
                return !1;
            var a = {
                11: {
                    0: [0],
                    1: [[0, 9], [11, 17]],
                    2: [0, 28, 29]
                },
                12: {
                    0: [0],
                    1: [[0, 16]],
                    2: [0, 21, 23, 25]
                },
                13: {
                    0: [0],
                    1: [[0, 5], 7, 8, 21, [23, 33], [81, 85]],
                    2: [[0, 5], [7, 9], [23, 25], 27, 29, 30, 81, 83],
                    3: [[0, 4], [21, 24]],
                    4: [[0, 4], 6, 21, [23, 35], 81],
                    5: [[0, 3], [21, 35], 81, 82],
                    6: [[0, 4], [21, 38], [81, 84]],
                    7: [[0, 3], 5, 6, [21, 33]],
                    8: [[0, 4], [21, 28]],
                    9: [[0, 3], [21, 30], [81, 84]],
                    10: [[0, 3], [22, 26], 28, 81, 82],
                    11: [[0, 2], [21, 28], 81, 82]
                },
                14: {
                    0: [0],
                    1: [0, 1, [5, 10], [21, 23], 81],
                    2: [[0, 3], 11, 12, [21, 27]],
                    3: [[0, 3], 11, 21, 22],
                    4: [[0, 2], 11, 21, [23, 31], 81],
                    5: [[0, 2], 21, 22, 24, 25, 81],
                    6: [[0, 3], [21, 24]],
                    7: [[0, 2], [21, 29], 81],
                    8: [[0, 2], [21, 30], 81, 82],
                    9: [[0, 2], [21, 32], 81],
                    10: [[0, 2], [21, 34], 81, 82],
                    11: [[0, 2], [21, 30], 81, 82],
                    23: [[0, 3], 22, 23, [25, 30], 32, 33]
                },
                15: {
                    0: [0],
                    1: [[0, 5], [21, 25]],
                    2: [[0, 7], [21, 23]],
                    3: [[0, 4]],
                    4: [[0, 4], [21, 26], [28, 30]],
                    5: [[0, 2], [21, 26], 81],
                    6: [[0, 2], [21, 27]],
                    7: [[0, 3], [21, 27], [81, 85]],
                    8: [[0, 2], [21, 26]],
                    9: [[0, 2], [21, 29], 81],
                    22: [[0, 2], [21, 24]],
                    25: [[0, 2], [22, 31]],
                    26: [[0, 2], [24, 27], [29, 32], 34],
                    28: [0, 1, [22, 27]],
                    29: [0, [21, 23]]
                },
                21: {
                    0: [0],
                    1: [[0, 6], [11, 14], [22, 24], 81],
                    2: [[0, 4], [11, 13], 24, [81, 83]],
                    3: [[0, 4], 11, 21, 23, 81],
                    4: [[0, 4], 11, [21, 23]],
                    5: [[0, 5], 21, 22],
                    6: [[0, 4], 24, 81, 82],
                    7: [[0, 3], 11, 26, 27, 81, 82],
                    8: [[0, 4], 11, 81, 82],
                    9: [[0, 5], 11, 21, 22],
                    10: [[0, 5], 11, 21, 81],
                    11: [[0, 3], 21, 22],
                    12: [[0, 2], 4, 21, 23, 24, 81, 82],
                    13: [[0, 3], 21, 22, 24, 81, 82],
                    14: [[0, 4], 21, 22, 81]
                },
                22: {
                    0: [0],
                    1: [[0, 6], 12, 22, [81, 83]],
                    2: [[0, 4], 11, 21, [81, 84]],
                    3: [[0, 3], 22, 23, 81, 82],
                    4: [[0, 3], 21, 22],
                    5: [[0, 3], 21, 23, 24, 81, 82],
                    6: [[0, 2], 4, 5, [21, 23], 25, 81],
                    7: [[0, 2], [21, 24], 81],
                    8: [[0, 2], 21, 22, 81, 82],
                    24: [[0, 6], 24, 26]
                },
                23: {
                    0: [0],
                    1: [[0, 12], 21, [23, 29], [81, 84]],
                    2: [[0, 8], 21, [23, 25], 27, [29, 31], 81],
                    3: [[0, 7], 21, 81, 82],
                    4: [[0, 7], 21, 22],
                    5: [[0, 3], 5, 6, [21, 24]],
                    6: [[0, 6], [21, 24]],
                    7: [[0, 16], 22, 81],
                    8: [[0, 5], 11, 22, 26, 28, 33, 81, 82],
                    9: [[0, 4], 21],
                    10: [[0, 5], 24, 25, 81, [83, 85]],
                    11: [[0, 2], 21, 23, 24, 81, 82],
                    12: [[0, 2], [21, 26], [81, 83]],
                    27: [[0, 4], [21, 23]]
                },
                31: {
                    0: [0],
                    1: [0, 1, [3, 10], [12, 20]],
                    2: [0, 30]
                },
                32: {
                    0: [0],
                    1: [[0, 7], 11, [13, 18], 24, 25],
                    2: [[0, 6], 11, 81, 82],
                    3: [[0, 5], 11, 12, [21, 24], 81, 82],
                    4: [[0, 2], 4, 5, 11, 12, 81, 82],
                    5: [[0, 9], [81, 85]],
                    6: [[0, 2], 11, 12, 21, 23, [81, 84]],
                    7: [0, 1, 3, 5, 6, [21, 24]],
                    8: [[0, 4], 11, 26, [29, 31]],
                    9: [[0, 3], [21, 25], 28, 81, 82],
                    10: [[0, 3], 11, 12, 23, 81, 84, 88],
                    11: [[0, 2], 11, 12, [81, 83]],
                    12: [[0, 4], [81, 84]],
                    13: [[0, 2], 11, [21, 24]]
                },
                33: {
                    0: [0],
                    1: [[0, 6], [8, 10], 22, 27, 82, 83, 85],
                    2: [0, 1, [3, 6], 11, 12, 25, 26, [81, 83]],
                    3: [[0, 4], 22, 24, [26, 29], 81, 82],
                    4: [[0, 2], 11, 21, 24, [81, 83]],
                    5: [[0, 3], [21, 23]],
                    6: [[0, 2], 21, 24, [81, 83]],
                    7: [[0, 3], 23, 26, 27, [81, 84]],
                    8: [[0, 3], 22, 24, 25, 81],
                    9: [[0, 3], 21, 22],
                    10: [[0, 4], [21, 24], 81, 82],
                    11: [[0, 2], [21, 27], 81]
                },
                34: {
                    0: [0],
                    1: [[0, 4], 11, [21, 24], 81],
                    2: [[0, 4], 7, 8, [21, 23], 25],
                    3: [[0, 4], 11, [21, 23]],
                    4: [[0, 6], 21],
                    5: [[0, 4], 6, [21, 23]],
                    6: [[0, 4], 21],
                    7: [[0, 3], 11, 21],
                    8: [[0, 3], 11, [22, 28], 81],
                    10: [[0, 4], [21, 24]],
                    11: [[0, 3], 22, [24, 26], 81, 82],
                    12: [[0, 4], 21, 22, 25, 26, 82],
                    13: [[0, 2], [21, 24]],
                    14: [[0, 2], [21, 24]],
                    15: [[0, 3], [21, 25]],
                    16: [[0, 2], [21, 23]],
                    17: [[0, 2], [21, 23]],
                    18: [[0, 2], [21, 25], 81]
                },
                35: {
                    0: [0],
                    1: [[0, 5], 11, [21, 25], 28, 81, 82],
                    2: [[0, 6], [11, 13]],
                    3: [[0, 5], 22],
                    4: [[0, 3], 21, [23, 30], 81],
                    5: [[0, 5], 21, [24, 27], [81, 83]],
                    6: [[0, 3], [22, 29], 81],
                    7: [[0, 2], [21, 25], [81, 84]],
                    8: [[0, 2], [21, 25], 81],
                    9: [[0, 2], [21, 26], 81, 82]
                },
                36: {
                    0: [0],
                    1: [[0, 5], 11, [21, 24]],
                    2: [[0, 3], 22, 81],
                    3: [[0, 2], 13, [21, 23]],
                    4: [[0, 3], 21, [23, 30], 81, 82],
                    5: [[0, 2], 21],
                    6: [[0, 2], 22, 81],
                    7: [[0, 2], [21, 35], 81, 82],
                    8: [[0, 3], [21, 30], 81],
                    9: [[0, 2], [21, 26], [81, 83]],
                    10: [[0, 2], [21, 30]],
                    11: [[0, 2], [21, 30], 81]
                },
                37: {
                    0: [0],
                    1: [[0, 5], 12, 13, [24, 26], 81],
                    2: [[0, 3], 5, [11, 14], [81, 85]],
                    3: [[0, 6], [21, 23]],
                    4: [[0, 6], 81],
                    5: [[0, 3], [21, 23]],
                    6: [[0, 2], [11, 13], 34, [81, 87]],
                    7: [[0, 5], 24, 25, [81, 86]],
                    8: [[0, 2], 11, [26, 32], [81, 83]],
                    9: [[0, 3], 11, 21, 23, 82, 83],
                    10: [[0, 2], [81, 83]],
                    11: [[0, 3], 21, 22],
                    12: [[0, 3]],
                    13: [[0, 2], 11, 12, [21, 29]],
                    14: [[0, 2], [21, 28], 81, 82],
                    15: [[0, 2], [21, 26], 81],
                    16: [[0, 2], [21, 26]],
                    17: [[0, 2], [21, 28]]
                },
                41: {
                    0: [0],
                    1: [[0, 6], 8, 22, [81, 85]],
                    2: [[0, 5], 11, [21, 25]],
                    3: [[0, 7], 11, [22, 29], 81],
                    4: [[0, 4], 11, [21, 23], 25, 81, 82],
                    5: [[0, 3], 5, 6, 22, 23, 26, 27, 81],
                    6: [[0, 3], 11, 21, 22],
                    7: [[0, 4], 11, 21, [24, 28], 81, 82],
                    8: [[0, 4], 11, [21, 23], 25, [81, 83]],
                    9: [[0, 2], 22, 23, [26, 28]],
                    10: [[0, 2], [23, 25], 81, 82],
                    11: [[0, 4], [21, 23]],
                    12: [[0, 2], 21, 22, 24, 81, 82],
                    13: [[0, 3], [21, 30], 81],
                    14: [[0, 3], [21, 26], 81],
                    15: [[0, 3], [21, 28]],
                    16: [[0, 2], [21, 28], 81],
                    17: [[0, 2], [21, 29]],
                    90: [0, 1]
                },
                42: {
                    0: [0],
                    1: [[0, 7], [11, 17]],
                    2: [[0, 5], 22, 81],
                    3: [[0, 3], [21, 25], 81],
                    5: [[0, 6], [25, 29], [81, 83]],
                    6: [[0, 2], 6, 7, [24, 26], [82, 84]],
                    7: [[0, 4]],
                    8: [[0, 2], 4, 21, 22, 81],
                    9: [[0, 2], [21, 23], 81, 82, 84],
                    10: [[0, 3], [22, 24], 81, 83, 87],
                    11: [[0, 2], [21, 27], 81, 82],
                    12: [[0, 2], [21, 24], 81],
                    13: [[0, 3], 21, 81],
                    28: [[0, 2], 22, 23, [25, 28]],
                    90: [0, [4, 6], 21]
                },
                43: {
                    0: [0],
                    1: [[0, 5], 11, 12, 21, 22, 24, 81],
                    2: [[0, 4], 11, 21, [23, 25], 81],
                    3: [[0, 2], 4, 21, 81, 82],
                    4: [0, 1, [5, 8], 12, [21, 24], 26, 81, 82],
                    5: [[0, 3], 11, [21, 25], [27, 29], 81],
                    6: [[0, 3], 11, 21, 23, 24, 26, 81, 82],
                    7: [[0, 3], [21, 26], 81],
                    8: [[0, 2], 11, 21, 22],
                    9: [[0, 3], [21, 23], 81],
                    10: [[0, 3], [21, 28], 81],
                    11: [[0, 3], [21, 29]],
                    12: [[0, 2], [21, 30], 81],
                    13: [[0, 2], 21, 22, 81, 82],
                    31: [0, 1, [22, 27], 30]
                },
                44: {
                    0: [0],
                    1: [[0, 7], [11, 16], 83, 84],
                    2: [[0, 5], 21, 22, 24, 29, 32, 33, 81, 82],
                    3: [0, 1, [3, 8]],
                    4: [[0, 4]],
                    5: [0, 1, [6, 15], 23, 82, 83],
                    6: [0, 1, [4, 8]],
                    7: [0, 1, [3, 5], 81, [83, 85]],
                    8: [[0, 4], 11, 23, 25, [81, 83]],
                    9: [[0, 3], 23, [81, 83]],
                    12: [[0, 3], [23, 26], 83, 84],
                    13: [[0, 3], [22, 24], 81],
                    14: [[0, 2], [21, 24], 26, 27, 81],
                    15: [[0, 2], 21, 23, 81],
                    16: [[0, 2], [21, 25]],
                    17: [[0, 2], 21, 23, 81],
                    18: [[0, 3], 21, 23, [25, 27], 81, 82],
                    19: [0],
                    20: [0],
                    51: [[0, 3], 21, 22],
                    52: [[0, 3], 21, 22, 24, 81],
                    53: [[0, 2], [21, 23], 81]
                },
                45: {
                    0: [0],
                    1: [[0, 9], [21, 27]],
                    2: [[0, 5], [21, 26]],
                    3: [[0, 5], 11, 12, [21, 32]],
                    4: [0, 1, [3, 6], 11, [21, 23], 81],
                    5: [[0, 3], 12, 21],
                    6: [[0, 3], 21, 81],
                    7: [[0, 3], 21, 22],
                    8: [[0, 4], 21, 81],
                    9: [[0, 3], [21, 24], 81],
                    10: [[0, 2], [21, 31]],
                    11: [[0, 2], [21, 23]],
                    12: [[0, 2], [21, 29], 81],
                    13: [[0, 2], [21, 24], 81],
                    14: [[0, 2], [21, 25], 81]
                },
                46: {
                    0: [0],
                    1: [0, 1, [5, 8]],
                    2: [0, 1],
                    3: [0, [21, 23]],
                    90: [[0, 3], [5, 7], [21, 39]]
                },
                50: {
                    0: [0],
                    1: [[0, 19]],
                    2: [0, [22, 38], [40, 43]],
                    3: [0, [81, 84]]
                },
                51: {
                    0: [0],
                    1: [0, 1, [4, 8], [12, 15], [21, 24], 29, 31, 32, [81, 84]],
                    3: [[0, 4], 11, 21, 22],
                    4: [[0, 3], 11, 21, 22],
                    5: [[0, 4], 21, 22, 24, 25],
                    6: [0, 1, 3, 23, 26, [81, 83]],
                    7: [0, 1, 3, 4, [22, 27], 81],
                    8: [[0, 2], 11, 12, [21, 24]],
                    9: [[0, 4], [21, 23]],
                    10: [[0, 2], 11, 24, 25, 28],
                    11: [[0, 2], [11, 13], 23, 24, 26, 29, 32, 33, 81],
                    13: [[0, 4], [21, 25], 81],
                    14: [[0, 2], [21, 25]],
                    15: [[0, 3], [21, 29]],
                    16: [[0, 3], [21, 23], 81],
                    17: [[0, 3], [21, 25], 81],
                    18: [[0, 3], [21, 27]],
                    19: [[0, 3], [21, 23]],
                    20: [[0, 2], 21, 22, 81],
                    32: [0, [21, 33]],
                    33: [0, [21, 38]],
                    34: [0, 1, [22, 37]]
                },
                52: {
                    0: [0],
                    1: [[0, 3], [11, 15], [21, 23], 81],
                    2: [0, 1, 3, 21, 22],
                    3: [[0, 3], [21, 30], 81, 82],
                    4: [[0, 2], [21, 25]],
                    5: [[0, 2], [21, 27]],
                    6: [[0, 3], [21, 28]],
                    22: [0, 1, [22, 30]],
                    23: [0, 1, [22, 28]],
                    24: [0, 1, [22, 28]],
                    26: [0, 1, [22, 36]],
                    27: [[0, 2], 22, 23, [25, 32]]
                },
                53: {
                    0: [0],
                    1: [[0, 3], [11, 14], 21, 22, [24, 29], 81],
                    3: [[0, 2], [21, 26], 28, 81],
                    4: [[0, 2], [21, 28]],
                    5: [[0, 2], [21, 24]],
                    6: [[0, 2], [21, 30]],
                    7: [[0, 2], [21, 24]],
                    8: [[0, 2], [21, 29]],
                    9: [[0, 2], [21, 27]],
                    23: [0, 1, [22, 29], 31],
                    25: [[0, 4], [22, 32]],
                    26: [0, 1, [21, 28]],
                    27: [0, 1, [22, 30]],
                    28: [0, 1, 22, 23],
                    29: [0, 1, [22, 32]],
                    31: [0, 2, 3, [22, 24]],
                    34: [0, [21, 23]],
                    33: [0, 21, [23, 25]],
                    35: [0, [21, 28]]
                },
                54: {
                    0: [0],
                    1: [[0, 2], [21, 27]],
                    21: [0, [21, 29], 32, 33],
                    22: [0, [21, 29], [31, 33]],
                    23: [0, 1, [22, 38]],
                    24: [0, [21, 31]],
                    25: [0, [21, 27]],
                    26: [0, [21, 27]]
                },
                61: {
                    0: [0],
                    1: [[0, 4], [11, 16], 22, [24, 26]],
                    2: [[0, 4], 22],
                    3: [[0, 4], [21, 24], [26, 31]],
                    4: [[0, 4], [22, 31], 81],
                    5: [[0, 2], [21, 28], 81, 82],
                    6: [[0, 2], [21, 32]],
                    7: [[0, 2], [21, 30]],
                    8: [[0, 2], [21, 31]],
                    9: [[0, 2], [21, 29]],
                    10: [[0, 2], [21, 26]]
                },
                62: {
                    0: [0],
                    1: [[0, 5], 11, [21, 23]],
                    2: [0, 1],
                    3: [[0, 2], 21],
                    4: [[0, 3], [21, 23]],
                    5: [[0, 3], [21, 25]],
                    6: [[0, 2], [21, 23]],
                    7: [[0, 2], [21, 25]],
                    8: [[0, 2], [21, 26]],
                    9: [[0, 2], [21, 24], 81, 82],
                    10: [[0, 2], [21, 27]],
                    11: [[0, 2], [21, 26]],
                    12: [[0, 2], [21, 28]],
                    24: [0, 21, [24, 29]],
                    26: [0, 21, [23, 30]],
                    29: [0, 1, [21, 27]],
                    30: [0, 1, [21, 27]]
                },
                63: {
                    0: [0],
                    1: [[0, 5], [21, 23]],
                    2: [0, 2, [21, 25]],
                    21: [0, [21, 23], [26, 28]],
                    22: [0, [21, 24]],
                    23: [0, [21, 24]],
                    25: [0, [21, 25]],
                    26: [0, [21, 26]],
                    27: [0, 1, [21, 26]],
                    28: [[0, 2], [21, 23]]
                },
                64: {
                    0: [0],
                    1: [0, 1, [4, 6], 21, 22, 81],
                    2: [[0, 3], 5, [21, 23]],
                    3: [[0, 3], [21, 24], 81],
                    4: [[0, 2], [21, 25]],
                    5: [[0, 2], 21, 22]
                },
                65: {
                    0: [0],
                    1: [[0, 9], 21],
                    2: [[0, 5]],
                    21: [0, 1, 22, 23],
                    22: [0, 1, 22, 23],
                    23: [[0, 3], [23, 25], 27, 28],
                    28: [0, 1, [22, 29]],
                    29: [0, 1, [22, 29]],
                    30: [0, 1, [22, 24]],
                    31: [0, 1, [21, 31]],
                    32: [0, 1, [21, 27]],
                    40: [0, 2, 3, [21, 28]],
                    42: [[0, 2], 21, [23, 26]],
                    43: [0, 1, [21, 26]],
                    90: [[0, 4]],
                    27: [[0, 2], 22, 23]
                },
                71: {
                    0: [0]
                },
                81: {
                    0: [0]
                },
                82: {
                    0: [0]
                }
            }
              , i = parseInt(e.substr(0, 2), 10)
              , r = parseInt(e.substr(2, 2), 10)
              , s = parseInt(e.substr(4, 2), 10);
            if (!a[i] || !a[i][r])
                return !1;
            for (var n = !1, o = a[i][r], l = 0; l < o.length; l++)
                if (t.isArray(o[l]) && o[l][0] <= s && s <= o[l][1] || !t.isArray(o[l]) && s === o[l]) {
                    n = !0;
                    break
                }
            if (!n)
                return !1;
            var d;
            d = 18 === e.length ? e.substr(6, 8) : "19" + e.substr(6, 6);
            var u = parseInt(d.substr(0, 4), 10)
              , f = parseInt(d.substr(4, 2), 10)
              , c = parseInt(d.substr(6, 2), 10);
            if (!FormValidation.Helper.date(u, f, c))
                return !1;
            if (18 === e.length) {
                var h = 0
                  , p = [7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2];
                for (l = 0; 17 > l; l++)
                    h += parseInt(e.charAt(l), 10) * p[l];
                h = (12 - h % 11) % 11;
                var m = "X" !== e.charAt(17).toUpperCase() ? parseInt(e.charAt(17), 10) : 10;
                return m === h
            }
            return !0
        },
        _cz: function (t) {
            if (!/^\d{9,10}$/.test(t))
                return !1;
            var e = 1900 + parseInt(t.substr(0, 2), 10)
              , a = parseInt(t.substr(2, 2), 10) % 50 % 20
              , i = parseInt(t.substr(4, 2), 10);
            if (9 === t.length) {
                if (e >= 1980 && (e -= 100),
                e > 1953)
                    return !1
            } else
                1954 > e && (e += 100);
            if (!FormValidation.Helper.date(e, a, i))
                return !1;
            if (10 === t.length) {
                var r = parseInt(t.substr(0, 9), 10) % 11;
                return 1985 > e && (r %= 10),
                r + "" === t.substr(9, 1)
            }
            return !0
        },
        _dk: function (t) {
            if (!/^[0-9]{6}[-]{0,1}[0-9]{4}$/.test(t))
                return !1;
            t = t.replace(/-/g, "");
            var e = parseInt(t.substr(0, 2), 10)
              , a = parseInt(t.substr(2, 2), 10)
              , i = parseInt(t.substr(4, 2), 10);
            switch (!0) {
                case -1 !== "5678".indexOf(t.charAt(6)) && i >= 58:
                    i += 1800;
                    break;
                case -1 !== "0123".indexOf(t.charAt(6)):
                case -1 !== "49".indexOf(t.charAt(6)) && i >= 37:
                    i += 1900;
                    break;
                default:
                    i += 2e3
            }
            return FormValidation.Helper.date(i, a, e)
        },
        _ee: function (t) {
            return this._lt(t)
        },
        _es: function (t) {
            var e = /^[0-9]{8}[-]{0,1}[A-HJ-NP-TV-Z]$/.test(t)
              , a = /^[XYZ][-]{0,1}[0-9]{7}[-]{0,1}[A-HJ-NP-TV-Z]$/.test(t)
              , i = /^[A-HNPQS][-]{0,1}[0-9]{7}[-]{0,1}[0-9A-J]$/.test(t);
            if (!e && !a && !i)
                return !1;
            t = t.replace(/-/g, "");
            var r, s, n = !0;
            if (e || a) {
                s = "DNI";
                var o = "XYZ".indexOf(t.charAt(0));
                return -1 !== o && (t = o + t.substr(1) + "",
                s = "NIE"),
                r = parseInt(t.substr(0, 8), 10),
                r = "TRWAGMYFPDXBNJZSQVHLCKE"[r % 23],
                {
                    valid: r === t.substr(8, 1),
                    type: s
                }
            }
            r = t.substr(1, 7),
            s = "CIF";
            for (var l = t[0], d = t.substr(-1), u = 0, f = 0; f < r.length; f++)
                if (f % 2 !== 0)
                    u += parseInt(r[f], 10);
                else {
                    var c = "" + 2 * parseInt(r[f], 10);
                    u += parseInt(c[0], 10),
                    2 === c.length && (u += parseInt(c[1], 10))
                }
            var h = u - 10 * Math.floor(u / 10);
            return 0 !== h && (h = 10 - h),
            n = -1 !== "KQS".indexOf(l) ? d === "JABCDEFGHI"[h] : -1 !== "ABEH".indexOf(l) ? d === "" + h : d === "" + h || d === "JABCDEFGHI"[h],
            {
                valid: n,
                type: s
            }
        },
        _fi: function (t) {
            if (!/^[0-9]{6}[-+A][0-9]{3}[0-9ABCDEFHJKLMNPRSTUVWXY]$/.test(t))
                return !1;
            var e = parseInt(t.substr(0, 2), 10)
              , a = parseInt(t.substr(2, 2), 10)
              , i = parseInt(t.substr(4, 2), 10)
              , r = {
                  "+": 1800,
                  "-": 1900,
                  A: 2e3
              };
            if (i = r[t.charAt(6)] + i,
            !FormValidation.Helper.date(i, a, e))
                return !1;
            var s = parseInt(t.substr(7, 3), 10);
            if (2 > s)
                return !1;
            var n = t.substr(0, 6) + t.substr(7, 3) + "";
            return n = parseInt(n, 10),
            "0123456789ABCDEFHJKLMNPRSTUVWXY".charAt(n % 31) === t.charAt(10)
        },
        _hr: function (t) {
            return /^[0-9]{11}$/.test(t) ? FormValidation.Helper.mod11And10(t) : !1
        },
        _ie: function (t) {
            if (!/^\d{7}[A-W][AHWTX]?$/.test(t))
                return !1;
            var e = function (t) {
                for (; t.length < 7;)
                    t = "0" + t;
                for (var e = "WABCDEFGHIJKLMNOPQRSTUV", a = 0, i = 0; 7 > i; i++)
                    a += parseInt(t.charAt(i), 10) * (8 - i);
                return a += 9 * e.indexOf(t.substr(7)),
                e[a % 23]
            }
            ;
            return 9 !== t.length || "A" !== t.charAt(8) && "H" !== t.charAt(8) ? t.charAt(7) === e(t.substr(0, 7)) : t.charAt(7) === e(t.substr(0, 7) + t.substr(8) + "")
        },
        _is: function (t) {
            if (!/^[0-9]{6}[-]{0,1}[0-9]{4}$/.test(t))
                return !1;
            t = t.replace(/-/g, "");
            var e = parseInt(t.substr(0, 2), 10)
              , a = parseInt(t.substr(2, 2), 10)
              , i = parseInt(t.substr(4, 2), 10)
              , r = parseInt(t.charAt(9), 10);
            if (i = 9 === r ? 1900 + i : 100 * (20 + r) + i,
            !FormValidation.Helper.date(i, a, e, !0))
                return !1;
            for (var s = 0, n = [3, 2, 7, 6, 5, 4, 3, 2], o = 0; 8 > o; o++)
                s += parseInt(t.charAt(o), 10) * n[o];
            return s = 11 - s % 11,
            s + "" === t.charAt(8)
        },
        _lt: function (t) {
            if (!/^[0-9]{11}$/.test(t))
                return !1;
            var e = parseInt(t.charAt(0), 10)
              , a = parseInt(t.substr(1, 2), 10)
              , i = parseInt(t.substr(3, 2), 10)
              , r = parseInt(t.substr(5, 2), 10)
              , s = e % 2 === 0 ? 17 + e / 2 : 17 + (e + 1) / 2;
            if (a = 100 * s + a,
            !FormValidation.Helper.date(a, i, r, !0))
                return !1;
            for (var n = 0, o = [1, 2, 3, 4, 5, 6, 7, 8, 9, 1], l = 0; 10 > l; l++)
                n += parseInt(t.charAt(l), 10) * o[l];
            if (n %= 11,
            10 !== n)
                return n + "" === t.charAt(10);
            for (n = 0,
            o = [3, 4, 5, 6, 7, 8, 9, 1, 2, 3],
            l = 0; 10 > l; l++)
                n += parseInt(t.charAt(l), 10) * o[l];
            return n %= 11,
            10 === n && (n = 0),
            n + "" === t.charAt(10)
        },
        _lv: function (t) {
            if (!/^[0-9]{6}[-]{0,1}[0-9]{5}$/.test(t))
                return !1;
            t = t.replace(/\D/g, "");
            var e = parseInt(t.substr(0, 2), 10)
              , a = parseInt(t.substr(2, 2), 10)
              , i = parseInt(t.substr(4, 2), 10);
            if (i = i + 1800 + 100 * parseInt(t.charAt(6), 10),
            !FormValidation.Helper.date(i, a, e, !0))
                return !1;
            for (var r = 0, s = [10, 5, 8, 4, 2, 1, 6, 3, 7, 9], n = 0; 10 > n; n++)
                r += parseInt(t.charAt(n), 10) * s[n];
            return r = (r + 1) % 11 % 10,
            r + "" === t.charAt(10)
        },
        _nl: function (t) {
            if (t.length < 8)
                return !1;
            if (8 === t.length && (t = "0" + t),
            !/^[0-9]{4}[.]{0,1}[0-9]{2}[.]{0,1}[0-9]{3}$/.test(t))
                return !1;
            if (t = t.replace(/\./g, ""),
            0 === parseInt(t, 10))
                return !1;
            for (var e = 0, a = t.length, i = 0; a - 1 > i; i++)
                e += (9 - i) * parseInt(t.charAt(i), 10);
            return e %= 11,
            10 === e && (e = 0),
            e + "" === t.charAt(a - 1)
        },
        _pl: function (t) {
            if (!/^[0-9]{11}$/.test(t))
                return !1;
            for (var e = 0, a = t.length, i = [1, 3, 7, 9, 1, 3, 7, 9, 1, 3, 7], r = 0; a - 1 > r; r++)
                e += i[r] * parseInt(t.charAt(r), 10);
            return e %= 10,
            0 === e && (e = 10),
            e = 10 - e,
            e + "" === t.charAt(a - 1)
        },
        _ro: function (t) {
            if (!/^[0-9]{13}$/.test(t))
                return !1;
            var e = parseInt(t.charAt(0), 10);
            if (0 === e || 7 === e || 8 === e)
                return !1;
            var a = parseInt(t.substr(1, 2), 10)
              , i = parseInt(t.substr(3, 2), 10)
              , r = parseInt(t.substr(5, 2), 10)
              , s = {
                  1: 1900,
                  2: 1900,
                  3: 1800,
                  4: 1800,
                  5: 2e3,
                  6: 2e3
              };
            if (r > 31 && i > 12)
                return !1;
            if (9 !== e && (a = s[e + ""] + a,
            !FormValidation.Helper.date(a, i, r)))
                return !1;
            for (var n = 0, o = [2, 7, 9, 1, 4, 6, 3, 5, 8, 2, 7, 9], l = t.length, d = 0; l - 1 > d; d++)
                n += parseInt(t.charAt(d), 10) * o[d];
            return n %= 11,
            10 === n && (n = 1),
            n + "" === t.charAt(l - 1)
        },
        _se: function (t) {
            if (!/^[0-9]{10}$/.test(t) && !/^[0-9]{6}[-|+][0-9]{4}$/.test(t))
                return !1;
            t = t.replace(/[^0-9]/g, "");
            var e = parseInt(t.substr(0, 2), 10) + 1900
              , a = parseInt(t.substr(2, 2), 10)
              , i = parseInt(t.substr(4, 2), 10);
            return FormValidation.Helper.date(e, a, i) ? FormValidation.Helper.luhn(t) : !1
        },
        _sk: function (t) {
            return this._cz(t)
        },
        _sm: function (t) {
            return /^\d{5}$/.test(t)
        },
        _th: function (t) {
            if (13 !== t.length)
                return !1;
            for (var e = 0, a = 0; 12 > a; a++)
                e += parseInt(t.charAt(a), 10) * (13 - a);
            return (11 - e % 11) % 10 === parseInt(t.charAt(12), 10)
        },
        _za: function (t) {
            if (!/^[0-9]{10}[0|1][8|9][0-9]$/.test(t))
                return !1;
            var e = parseInt(t.substr(0, 2), 10)
              , a = (new Date).getFullYear() % 100
              , i = parseInt(t.substr(2, 2), 10)
              , r = parseInt(t.substr(4, 2), 10);
            return e = e >= a ? e + 1900 : e + 2e3,
            FormValidation.Helper.date(e, i, r) ? FormValidation.Helper.luhn(t) : !1
        }
    }
}
(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            identical: {
                "default": "Please enter the same value"
            }
        }
    }),
    FormValidation.Validator.identical = {
        html5Attributes: {
            message: "message",
            field: "field"
        },
        init: function (t, e, a, i) {
            var r = t.getFieldElements(a.field);
            t.onLiveChange(r, "live_" + i, function () {
                var a = t.getStatus(e, i);
                a !== t.STATUS_NOT_VALIDATED && t.revalidateField(e)
            })
        },
        destroy: function (t, e, a, i) {
            var r = t.getFieldElements(a.field);
            t.offLiveChange(r, "live_" + i)
        },
        validate: function (t, e, a, i) {
            var r = t.getFieldValue(e, i)
              , s = t.getFieldElements(a.field);
            if (null === s || 0 === s.length)
                return !0;
            var n = t.getFieldValue(s, i);
            return r === n ? (t.updateStatus(s, t.STATUS_VALID, i),
            !0) : !1
        }
    }
}
(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            imei: {
                "default": "Please enter a valid IMEI number"
            }
        }
    }),
    FormValidation.Validator.imei = {
        validate: function (t, e, a, i) {
            var r = t.getFieldValue(e, i);
            if ("" === r)
                return !0;
            switch (!0) {
                case /^\d{15}$/.test(r):
                case /^\d{2}-\d{6}-\d{6}-\d{1}$/.test(r):
                case /^\d{2}\s\d{6}\s\d{6}\s\d{1}$/.test(r):
                    return r = r.replace(/[^0-9]/g, ""),
                    FormValidation.Helper.luhn(r);
                case /^\d{14}$/.test(r):
                case /^\d{16}$/.test(r):
                case /^\d{2}-\d{6}-\d{6}(|-\d{2})$/.test(r):
                case /^\d{2}\s\d{6}\s\d{6}(|\s\d{2})$/.test(r):
                    return !0;
                default:
                    return !1
            }
        }
    }
}
(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            imo: {
                "default": "Please enter a valid IMO number"
            }
        }
    }),
    FormValidation.Validator.imo = {
        validate: function (t, e, a, i) {
            var r = t.getFieldValue(e, i);
            if ("" === r)
                return !0;
            if (!/^IMO \d{7}$/i.test(r))
                return !1;
            for (var s = 0, n = r.replace(/^.*(\d{7})$/, "$1"), o = 6; o >= 1; o--)
                s += n.slice(6 - o, -o) * (o + 1);
            return s % 10 === parseInt(n.charAt(6), 10)
        }
    }
}(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            integer: {
                "default": "Please enter a valid number"
            }
        }
    }),
    FormValidation.Validator.integer = {
        html5Attributes: {
            message: "message",
            thousandsseparator: "thousandsSeparator",
            decimalseparator: "decimalSeparator"
        },
        enableByHtml5: function (t) {
            return "number" === t.attr("type") && (void 0 === t.attr("step") || t.attr("step") % 1 === 0)
        },
        validate: function (t, e, a, i) {
            if (this.enableByHtml5(e) && e.get(0).validity && e.get(0).validity.badInput === !0)
                return !1;
            var r = t.getFieldValue(e, i);
            if ("" === r)
                return !0;
            var s = a.decimalSeparator || "."
              , n = a.thousandsSeparator || "";
            s = "." === s ? "\\." : s,
            n = "." === n ? "\\." : n;
            var o = new RegExp("^-?[0-9]{1,3}(" + n + "[0-9]{3})*(" + s + "[0-9]+)?$")
              , l = new RegExp(n, "g");
            return o.test(r) ? (n && (r = r.replace(l, "")),
            s && (r = r.replace(s, ".")),
            isNaN(r) || !isFinite(r) ? !1 : (r = parseFloat(r),
            Math.floor(r) === r)) : !1
        }
    }
}
(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            ip: {
                "default": "Please enter a valid IP address",
                ipv4: "Please enter a valid IPv4 address",
                ipv6: "Please enter a valid IPv6 address"
            }
        }
    }),
    FormValidation.Validator.ip = {
        html5Attributes: {
            message: "message",
            ipv4: "ipv4",
            ipv6: "ipv6"
        },
        validate: function (e, a, i, r) {
            var s = e.getFieldValue(a, r);
            if ("" === s)
                return !0;
            i = t.extend({}, {
                ipv4: !0,
                ipv6: !0
            }, i);
            var n, o = e.getLocale(), l = /^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$/, d = /^\s*((([0-9A-Fa-f]{1,4}:){7}([0-9A-Fa-f]{1,4}|:))|(([0-9A-Fa-f]{1,4}:){6}(:[0-9A-Fa-f]{1,4}|((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3})|:))|(([0-9A-Fa-f]{1,4}:){5}(((:[0-9A-Fa-f]{1,4}){1,2})|:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3})|:))|(([0-9A-Fa-f]{1,4}:){4}(((:[0-9A-Fa-f]{1,4}){1,3})|((:[0-9A-Fa-f]{1,4})?:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){3}(((:[0-9A-Fa-f]{1,4}){1,4})|((:[0-9A-Fa-f]{1,4}){0,2}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){2}(((:[0-9A-Fa-f]{1,4}){1,5})|((:[0-9A-Fa-f]{1,4}){0,3}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){1}(((:[0-9A-Fa-f]{1,4}){1,6})|((:[0-9A-Fa-f]{1,4}){0,4}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(:(((:[0-9A-Fa-f]{1,4}){1,7})|((:[0-9A-Fa-f]{1,4}){0,5}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:)))(%.+)?\s*$/, u = !1;
            switch (!0) {
                case i.ipv4 && !i.ipv6:
                    u = l.test(s),
                    n = i.message || FormValidation.I18n[o].ip.ipv4;
                    break;
                case !i.ipv4 && i.ipv6:
                    u = d.test(s),
                    n = i.message || FormValidation.I18n[o].ip.ipv6;
                    break;
                case i.ipv4 && i.ipv6:
                default:
                    u = l.test(s) || d.test(s),
                    n = i.message || FormValidation.I18n[o].ip["default"]
            }
            return {
                valid: u,
                message: n
            }
        }
    }
}
(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            isbn: {
                "default": "Please enter a valid ISBN number"
            }
        }
    }),
    FormValidation.Validator.isbn = {
        validate: function (t, e, a, i) {
            var r = t.getFieldValue(e, i);
            if ("" === r)
                return !0;
            var s;
            switch (!0) {
                case /^\d{9}[\dX]$/.test(r):
                case 13 === r.length && /^(\d+)-(\d+)-(\d+)-([\dX])$/.test(r):
                case 13 === r.length && /^(\d+)\s(\d+)\s(\d+)\s([\dX])$/.test(r):
                    s = "ISBN10";
                    break;
                case /^(978|979)\d{9}[\dX]$/.test(r):
                case 17 === r.length && /^(978|979)-(\d+)-(\d+)-(\d+)-([\dX])$/.test(r):
                case 17 === r.length && /^(978|979)\s(\d+)\s(\d+)\s(\d+)\s([\dX])$/.test(r):
                    s = "ISBN13";
                    break;
                default:
                    return !1
            }
            r = r.replace(/[^0-9X]/gi, "");
            var n, o, l = r.split(""), d = l.length, u = 0;
            switch (s) {
                case "ISBN10":
                    for (u = 0,
                    n = 0; d - 1 > n; n++)
                        u += parseInt(l[n], 10) * (10 - n);
                    return o = 11 - u % 11,
                    11 === o ? o = 0 : 10 === o && (o = "X"),
                    {
                        type: s,
                        valid: o + "" === l[d - 1]
                    };
                case "ISBN13":
                    for (u = 0,
                    n = 0; d - 1 > n; n++)
                        u += n % 2 === 0 ? parseInt(l[n], 10) : 3 * parseInt(l[n], 10);
                    return o = 10 - u % 10,
                    10 === o && (o = "0"),
                    {
                        type: s,
                        valid: o + "" === l[d - 1]
                    };
                default:
                    return !1
            }
        }
    }
}(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            isin: {
                "default": "Please enter a valid ISIN number"
            }
        }
    }),
    FormValidation.Validator.isin = {
        COUNTRY_CODES: "AF|AX|AL|DZ|AS|AD|AO|AI|AQ|AG|AR|AM|AW|AU|AT|AZ|BS|BH|BD|BB|BY|BE|BZ|BJ|BM|BT|BO|BQ|BA|BW|BV|BR|IO|BN|BG|BF|BI|KH|CM|CA|CV|KY|CF|TD|CL|CN|CX|CC|CO|KM|CG|CD|CK|CR|CI|HR|CU|CW|CY|CZ|DK|DJ|DM|DO|EC|EG|SV|GQ|ER|EE|ET|FK|FO|FJ|FI|FR|GF|PF|TF|GA|GM|GE|DE|GH|GI|GR|GL|GD|GP|GU|GT|GG|GN|GW|GY|HT|HM|VA|HN|HK|HU|IS|IN|ID|IR|IQ|IE|IM|IL|IT|JM|JP|JE|JO|KZ|KE|KI|KP|KR|KW|KG|LA|LV|LB|LS|LR|LY|LI|LT|LU|MO|MK|MG|MW|MY|MV|ML|MT|MH|MQ|MR|MU|YT|MX|FM|MD|MC|MN|ME|MS|MA|MZ|MM|NA|NR|NP|NL|NC|NZ|NI|NE|NG|NU|NF|MP|NO|OM|PK|PW|PS|PA|PG|PY|PE|PH|PN|PL|PT|PR|QA|RE|RO|RU|RW|BL|SH|KN|LC|MF|PM|VC|WS|SM|ST|SA|SN|RS|SC|SL|SG|SX|SK|SI|SB|SO|ZA|GS|SS|ES|LK|SD|SR|SJ|SZ|SE|CH|SY|TW|TJ|TZ|TH|TL|TG|TK|TO|TT|TN|TR|TM|TC|TV|UG|UA|AE|GB|US|UM|UY|UZ|VU|VE|VN|VG|VI|WF|EH|YE|ZM|ZW",
        validate: function (t, e, a, i) {
            var r = t.getFieldValue(e, i);
            if ("" === r)
                return !0;
            r = r.toUpperCase();
            var s = new RegExp("^(" + this.COUNTRY_CODES + ")[0-9A-Z]{10}$");
            if (!s.test(r))
                return !1;
            for (var n = "", o = r.length, l = 0; o - 1 > l; l++) {
                var d = r.charCodeAt(l);
                n += d > 57 ? (d - 55).toString() : r.charAt(l)
            }
            var u = ""
              , f = n.length
              , c = f % 2 !== 0 ? 0 : 1;
            for (l = 0; f > l; l++)
                u += parseInt(n[l], 10) * (l % 2 === c ? 2 : 1) + "";
            var h = 0;
            for (l = 0; l < u.length; l++)
                h += parseInt(u.charAt(l), 10);
            return h = (10 - h % 10) % 10,
            h + "" === r.charAt(o - 1)
        }
    }
}(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            ismn: {
                "default": "Please enter a valid ISMN number"
            }
        }
    }),
    FormValidation.Validator.ismn = {
        validate: function (t, e, a, i) {
            var r = t.getFieldValue(e, i);
            if ("" === r)
                return !0;
            var s;
            switch (!0) {
                case /^M\d{9}$/.test(r):
                case /^M-\d{4}-\d{4}-\d{1}$/.test(r):
                case /^M\s\d{4}\s\d{4}\s\d{1}$/.test(r):
                    s = "ISMN10";
                    break;
                case /^9790\d{9}$/.test(r):
                case /^979-0-\d{4}-\d{4}-\d{1}$/.test(r):
                case /^979\s0\s\d{4}\s\d{4}\s\d{1}$/.test(r):
                    s = "ISMN13";
                    break;
                default:
                    return !1
            }
            "ISMN10" === s && (r = "9790" + r.substr(1)),
            r = r.replace(/[^0-9]/gi, "");
            for (var n = r.length, o = 0, l = [1, 3], d = 0; n - 1 > d; d++)
                o += parseInt(r.charAt(d), 10) * l[d % 2];
            return o = 10 - o % 10,
            {
                type: s,
                valid: o + "" === r.charAt(n - 1)
            }
        }
    }
}(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            issn: {
                "default": "Please enter a valid ISSN number"
            }
        }
    }),
    FormValidation.Validator.issn = {
        validate: function (t, e, a, i) {
            var r = t.getFieldValue(e, i);
            if ("" === r)
                return !0;
            if (!/^\d{4}\-\d{3}[\dX]$/.test(r))
                return !1;
            r = r.replace(/[^0-9X]/gi, "");
            var s = r.split("")
              , n = s.length
              , o = 0;
            "X" === s[7] && (s[7] = 10);
            for (var l = 0; n > l; l++)
                o += parseInt(s[l], 10) * (8 - l);
            return o % 11 === 0
        }
    }
}(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            lessThan: {
                "default": "Please enter a value less than or equal to %s",
                notInclusive: "Please enter a value less than %s"
            }
        }
    }),
    FormValidation.Validator.lessThan = {
        html5Attributes: {
            message: "message",
            value: "value",
            inclusive: "inclusive"
        },
        enableByHtml5: function (t) {
            var e = t.attr("type")
              , a = t.attr("max");
            return a && "date" !== e ? {
                value: a
            } : !1
        },
        validate: function (e, a, i, r) {
            var s = e.getFieldValue(a, r);
            if ("" === s)
                return !0;
            s = this._format(s);
            var n = e.getLocale()
              , o = t.isNumeric(i.value) ? i.value : e.getDynamicOption(a, i.value)
              , l = this._format(o);
            return i.inclusive === !0 || void 0 === i.inclusive ? {
                valid: t.isNumeric(s) && parseFloat(s) <= l,
                message: FormValidation.Helper.format(i.message || FormValidation.I18n[n].lessThan["default"], o)
            } : {
                valid: t.isNumeric(s) && parseFloat(s) < l,
                message: FormValidation.Helper.format(i.message || FormValidation.I18n[n].lessThan.notInclusive, o)
            }
        },
        _format: function (t) {
            return (t + "").replace(",", ".")
        }
    }
}
(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            mac: {
                "default": "Please enter a valid MAC address"
            }
        }
    }),
    FormValidation.Validator.mac = {
        validate: function (t, e, a, i) {
            var r = t.getFieldValue(e, i);
            return "" === r ? !0 : /^([0-9A-F]{2}[:-]){5}([0-9A-F]{2})$/.test(r)
        }
    }
}(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            meid: {
                "default": "Please enter a valid MEID number"
            }
        }
    }),
    FormValidation.Validator.meid = {
        validate: function (t, e, a, i) {
            var r = t.getFieldValue(e, i);
            if ("" === r)
                return !0;
            switch (!0) {
                case /^[0-9A-F]{15}$/i.test(r):
                case /^[0-9A-F]{2}[- ][0-9A-F]{6}[- ][0-9A-F]{6}[- ][0-9A-F]$/i.test(r):
                case /^\d{19}$/.test(r):
                case /^\d{5}[- ]\d{5}[- ]\d{4}[- ]\d{4}[- ]\d$/.test(r):
                    var s = r.charAt(r.length - 1);
                    if (r = r.replace(/[- ]/g, ""),
                    r.match(/^\d*$/i))
                        return FormValidation.Helper.luhn(r);
                    r = r.slice(0, -1);
                    for (var n = "", o = 1; 13 >= o; o += 2)
                        n += (2 * parseInt(r.charAt(o), 16)).toString(16);
                    var l = 0;
                    for (o = 0; o < n.length; o++)
                        l += parseInt(n.charAt(o), 16);
                    return l % 10 === 0 ? "0" === s : s === (2 * (10 * Math.floor((l + 10) / 10) - l)).toString(16);
                case /^[0-9A-F]{14}$/i.test(r):
                case /^[0-9A-F]{2}[- ][0-9A-F]{6}[- ][0-9A-F]{6}$/i.test(r):
                case /^\d{18}$/.test(r):
                case /^\d{5}[- ]\d{5}[- ]\d{4}[- ]\d{4}$/.test(r):
                    return !0;
                default:
                    return !1
            }
        }
    }
}(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            notEmpty: {
                "default": "Please enter a value"
            }
        }
    }),
    FormValidation.Validator.notEmpty = {
        enableByHtml5: function (t) {
            var e = t.attr("required") + "";
            return "required" === e || "true" === e
        },
        validate: function (e, a, i, r) {
            var s = a.attr("type");
            if ("radio" === s || "checkbox" === s) {
                var n = e.getNamespace();
                return e.getFieldElements(a.attr("data-" + n + "-field")).filter(":checked").length > 0
            }
            if ("number" === s && a.get(0).validity && a.get(0).validity.badInput === !0)
                return !0;
            var o = e.getFieldValue(a, r);
            return "" !== t.trim(o)
        }
    }
}(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            numeric: {
                "default": "Please enter a valid float number"
            }
        }
    }),
    FormValidation.Validator.numeric = {
        html5Attributes: {
            message: "message",
            separator: "separator",
            thousandsseparator: "thousandsSeparator",
            decimalseparator: "decimalSeparator"
        },
        enableByHtml5: function (t) {
            return "number" === t.attr("type") && void 0 !== t.attr("step") && t.attr("step") % 1 !== 0
        },
        validate: function (t, e, a, i) {
            if (this.enableByHtml5(e) && e.get(0).validity && e.get(0).validity.badInput === !0)
                return !1;
            var r = t.getFieldValue(e, i);
            if ("" === r)
                return !0;
            var s = a.separator || a.decimalSeparator || "."
              , n = a.thousandsSeparator || "";
            s = "." === s ? "\\." : s,
            n = "." === n ? "\\." : n;
            var o = new RegExp("^-?[0-9]{1,3}(" + n + "[0-9]{3})*(" + s + "[0-9]+)?$")
              , l = new RegExp(n, "g");
            return o.test(r) ? (n && (r = r.replace(l, "")),
            s && (r = r.replace(s, ".")),
            !isNaN(parseFloat(r)) && isFinite(r)) : !1
        }
    }
}
(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            phone: {
                "default": "Please enter a valid phone number",
                country: "Please enter a valid phone number in %s",
                countries: {
                    AE: "United Arab Emirates",
                    BG: "Bulgaria",
                    BR: "Brazil",
                    CN: "China",
                    CZ: "Czech Republic",
                    DE: "Germany",
                    DK: "Denmark",
                    ES: "Spain",
                    FR: "France",
                    GB: "United Kingdom",
                    IN: "India",
                    MA: "Morocco",
                    NL: "Netherlands",
                    PK: "Pakistan",
                    RO: "Romania",
                    RU: "Russia",
                    SK: "Slovakia",
                    TH: "Thailand",
                    US: "USA",
                    VE: "Venezuela"
                }
            }
        }
    }),
    FormValidation.Validator.phone = {
        html5Attributes: {
            message: "message",
            country: "country"
        },
        COUNTRY_CODES: ["AE", "BG", "BR", "CN", "CZ", "DE", "DK", "ES", "FR", "GB", "IN", "MA", "NL", "PK", "RO", "RU", "SK", "TH", "US", "VE"],
        validate: function (e, a, i, r) {
            var s = e.getFieldValue(a, r);
            if ("" === s)
                return !0;
            var n = e.getLocale()
              , o = i.country;
            if (("string" != typeof o || -1 === t.inArray(o, this.COUNTRY_CODES)) && (o = e.getDynamicOption(a, o)),
            !o || -1 === t.inArray(o.toUpperCase(), this.COUNTRY_CODES))
                return !0;
            var l = !0;
            switch (o.toUpperCase()) {
                case "AE":
                    s = t.trim(s),
                    l = /^(((\+|00)?971[\s\.-]?(\(0\)[\s\.-]?)?|0)(\(5(0|2|5|6)\)|5(0|2|5|6)|2|3|4|6|7|9)|60)([\s\.-]?[0-9]){7}$/.test(s);
                    break;
                case "BG":
                    s = s.replace(/\+|\s|-|\/|\(|\)/gi, ""),
                    l = /^(0|359|00)(((700|900)[0-9]{5}|((800)[0-9]{5}|(800)[0-9]{4}))|(87|88|89)([0-9]{7})|((2[0-9]{7})|(([3-9][0-9])(([0-9]{6})|([0-9]{5})))))$/.test(s);
                    break;
                case "BR":
                    s = t.trim(s),
                    l = /^(([\d]{4}[-.\s]{1}[\d]{2,3}[-.\s]{1}[\d]{2}[-.\s]{1}[\d]{2})|([\d]{4}[-.\s]{1}[\d]{3}[-.\s]{1}[\d]{4})|((\(?\+?[0-9]{2}\)?\s?)?(\(?\d{2}\)?\s?)?\d{4,5}[-.\s]?\d{4}))$/.test(s);
                    break;
                case "CN":
                    s = t.trim(s),
                    l = /^((00|\+)?(86(?:-| )))?((\d{11})|(\d{3}[- ]{1}\d{4}[- ]{1}\d{4})|((\d{2,4}[- ]){1}(\d{7,8}|(\d{3,4}[- ]{1}\d{4}))([- ]{1}\d{1,4})?))$/.test(s);
                    break;
                case "CZ":
                    l = /^(((00)([- ]?)|\+)(420)([- ]?))?((\d{3})([- ]?)){2}(\d{3})$/.test(s);
                    break;
                case "DE":
                    s = t.trim(s),
                    l = /^(((((((00|\+)49[ \-\/]?)|0)[1-9][0-9]{1,4})[ \-\/]?)|((((00|\+)49\()|\(0)[1-9][0-9]{1,4}\)[ \-\/]?))[0-9]{1,7}([ \-\/]?[0-9]{1,5})?)$/.test(s);
                    break;
                case "DK":
                    s = t.trim(s),
                    l = /^(\+45|0045|\(45\))?\s?[2-9](\s?\d){7}$/.test(s);
                    break;
                case "ES":
                    s = t.trim(s),
                    l = /^(?:(?:(?:\+|00)34\D?))?(?:5|6|7|8|9)(?:\d\D?){8}$/.test(s);
                    break;
                case "FR":
                    s = t.trim(s),
                    l = /^(?:(?:(?:\+|00)33[ ]?(?:\(0\)[ ]?)?)|0){1}[1-9]{1}([ .-]?)(?:\d{2}\1?){3}\d{2}$/.test(s);
                    break;
                case "GB":
                    s = t.trim(s),
                    l = /^\(?(?:(?:0(?:0|11)\)?[\s-]?\(?|\+)44\)?[\s-]?\(?(?:0\)?[\s-]?\(?)?|0)(?:\d{2}\)?[\s-]?\d{4}[\s-]?\d{4}|\d{3}\)?[\s-]?\d{3}[\s-]?\d{3,4}|\d{4}\)?[\s-]?(?:\d{5}|\d{3}[\s-]?\d{3})|\d{5}\)?[\s-]?\d{4,5}|8(?:00[\s-]?11[\s-]?11|45[\s-]?46[\s-]?4\d))(?:(?:[\s-]?(?:x|ext\.?\s?|\#)\d+)?)$/.test(s);
                    break;
                case "IN":
                    s = t.trim(s),
                    l = /((\+?)((0[ -]+)*|(91 )*)(\d{12}|\d{10}))|\d{5}([- ]*)\d{6}/.test(s);
                    break;
                case "MA":
                    s = t.trim(s),
                    l = /^(?:(?:(?:\+|00)212[\s]?(?:[\s]?\(0\)[\s]?)?)|0){1}(?:5[\s.-]?[2-3]|6[\s.-]?[13-9]){1}[0-9]{1}(?:[\s.-]?\d{2}){3}$/.test(s);
                    break;
                case "NL":
                    s = t.trim(s),
                    l = /^((\+|00(\s|\s?\-\s?)?)31(\s|\s?\-\s?)?(\(0\)[\-\s]?)?|0)[1-9]((\s|\s?\-\s?)?[0-9])((\s|\s?-\s?)?[0-9])((\s|\s?-\s?)?[0-9])\s?[0-9]\s?[0-9]\s?[0-9]\s?[0-9]\s?[0-9]$/gm.test(s);
                    break;
                case "PK":
                    s = t.trim(s),
                    l = /^0?3[0-9]{2}[0-9]{7}$/.test(s);
                    break;
                case "RO":
                    l = /^(\+4|)?(07[0-8]{1}[0-9]{1}|02[0-9]{2}|03[0-9]{2}){1}?(\s|\.|\-)?([0-9]{3}(\s|\.|\-|)){2}$/g.test(s);
                    break;
                case "RU":
                    l = /^((8|\+7|007)[\-\.\/ ]?)?([\(\/\.]?\d{3}[\)\/\.]?[\-\.\/ ]?)?[\d\-\.\/ ]{7,10}$/g.test(s);
                    break;
                case "SK":
                    l = /^(((00)([- ]?)|\+)(421)([- ]?))?((\d{3})([- ]?)){2}(\d{3})$/.test(s);
                    break;
                case "TH":
                    l = /^0\(?([6|8-9]{2})*-([0-9]{3})*-([0-9]{4})$/.test(s);
                    break;
                case "VE":
                    s = t.trim(s),
                    l = /^0(?:2(?:12|4[0-9]|5[1-9]|6[0-9]|7[0-8]|8[1-35-8]|9[1-5]|3[45789])|4(?:1[246]|2[46]))\d{7}$/.test(s);
                    break;
                case "US":
                default:
                    l = /^(?:(1\-?)|(\+1 ?))?\(?(\d{3})[\)\-\.]?(\d{3})[\-\.]?(\d{4})$/.test(s)
            }
            return {
                valid: l,
                message: FormValidation.Helper.format(i.message || FormValidation.I18n[n].phone.country, FormValidation.I18n[n].phone.countries[o])
            }
        }
    }
}
(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            promise: {
                "default": "Please enter a valid value"
            }
        }
    }),
    FormValidation.Validator.promise = {
        html5Attributes: {
            message: "message",
            promise: "promise"
        },
        validate: function (e, a, i, r) {
            var s = e.getFieldValue(a, r)
              , n = new t.Deferred
              , o = FormValidation.Helper.call(i.promise, [s, e, a]);
            return o.done(function (t) {
                n.resolve(a, r, t)
            }).fail(function (t) {
                t = t || {},
                t.valid = !1,
                n.resolve(a, r, t)
            }),
            n
        }
    }
}
(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            regexp: {
                "default": "Please enter a value matching the pattern"
            }
        }
    }),
    FormValidation.Validator.regexp = {
        html5Attributes: {
            message: "message",
            regexp: "regexp"
        },
        enableByHtml5: function (t) {
            var e = t.attr("pattern");
            return e ? {
                regexp: e
            } : !1
        },
        validate: function (t, e, a, i) {
            var r = t.getFieldValue(e, i);
            if ("" === r)
                return !0;
            var s = "string" == typeof a.regexp ? new RegExp(a.regexp) : a.regexp;
            return s.test(r)
        }
    }
}
(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            remote: {
                "default": "Please enter a valid value"
            }
        }
    }),
    FormValidation.Validator.remote = {
        html5Attributes: {
            crossdomain: "crossDomain",
            data: "data",
            datatype: "dataType",
            delay: "delay",
            message: "message",
            name: "name",
            type: "type",
            url: "url",
            validkey: "validKey"
        },
        destroy: function (t, e, a, i) {
            var r = t.getNamespace()
              ,
            s = e.data(r + "." + i + ".timer");
            s && (clearTimeout(s),
            e.removeData(r + "." + i + ".timer"))
        },
        validate: function (e, a, i, r) {
            function s() {
                var e = t.ajax(h);
                return e.success(function (t) {
                    t.valid = t[c] === !0 || "true" === t[c] ? !0 : t[c] === !1 || "false" === t[c] ? !1 : null,
                    l.resolve(a, r, t)
                }).error(function (t) {
                    l.resolve(a, r, {
                        valid: !1
                    })
                }),
                l.fail(function () {
                    e.abort()
                }),
                l
            }
            var n = e.getNamespace(),
            o = e.getFieldValue(a, r),
            l = new t.Deferred;
            if ("" === o)
                return l.resolve(a, r, {
                    valid: !0
                }),
                l;
            var d = a.attr("data-" + n + "-field"),
            u = i.data || {},
            f = i.url,
            c = i.validKey || "valid";
            "function" == typeof u && (u = u.call(this, e, a, o)),
            "string" == typeof u && (u = JSON.parse(u)),
            "function" == typeof f && (f = f.call(this, e, a, o)),
            u[i.name || d] = o;
            
            var h = {
                data: u,
                dataType: i.dataType || "json",
                headers: i.headers || {},
                type: i.type || "GET",
                url: f
            };
            return null !== i.crossDomain && (h.crossDomain = i.crossDomain === !0 || "true" === i.crossDomain),
            i.delay ? (a.data(n + "." + r + ".timer") && clearTimeout(a.data(n + "." + r + ".timer")),
            a.data(n + "." + r + ".timer", setTimeout(s, i.delay)),
            l) : s()
        }
    }
}(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            rtn: {
                "default": "Please enter a valid RTN number"
            }
        }
    }),
    FormValidation.Validator.rtn = {
        validate: function (t, e, a, i) {
            var r = t.getFieldValue(e, i);
            if ("" === r)
                return !0;
            if (!/^\d{9}$/.test(r))
                return !1;
            for (var s = 0, n = 0; n < r.length; n += 3)
                s += 3 * parseInt(r.charAt(n), 10) + 7 * parseInt(r.charAt(n + 1), 10) + parseInt(r.charAt(n + 2), 10);
            return 0 !== s && s % 10 === 0
        }
    }
}(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            sedol: {
                "default": "Please enter a valid SEDOL number"
            }
        }
    }),
    FormValidation.Validator.sedol = {
        validate: function (t, e, a, i) {
            var r = t.getFieldValue(e, i);
            if ("" === r)
                return !0;
            if (r = r.toUpperCase(),
            !/^[0-9A-Z]{7}$/.test(r))
                return !1;
            for (var s = 0, n = [1, 3, 1, 7, 3, 9, 1], o = r.length, l = 0; o - 1 > l; l++)
                s += n[l] * parseInt(r.charAt(l), 36);
            return s = (10 - s % 10) % 10,
            s + "" === r.charAt(o - 1)
        }
    }
}(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            siren: {
                "default": "Please enter a valid SIREN number"
            }
        }
    }),
    FormValidation.Validator.siren = {
        validate: function (t, e, a, i) {
            var r = t.getFieldValue(e, i);
            return "" === r ? !0 : /^\d{9}$/.test(r) ? FormValidation.Helper.luhn(r) : !1
        }
    }
}(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            siret: {
                "default": "Please enter a valid SIRET number"
            }
        }
    }),
    FormValidation.Validator.siret = {
        validate: function (t, e, a, i) {
            var r = t.getFieldValue(e, i);
            if ("" === r)
                return !0;
            for (var s, n = 0, o = r.length, l = 0; o > l; l++)
                s = parseInt(r.charAt(l), 10),
                l % 2 === 0 && (s = 2 * s,
                s > 9 && (s -= 9)),
                n += s;
            return n % 10 === 0
        }
    }
}(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            step: {
                "default": "Please enter a valid step of %s"
            }
        }
    }),
    FormValidation.Validator.step = {
        html5Attributes: {
            message: "message",
            base: "baseValue",
            step: "step"
        },
        validate: function (e, a, i, r) {
            var s = e.getFieldValue(a, r);
            if ("" === s)
                return !0;
            if (i = t.extend({}, {
                baseValue: 0,
                step: 1
            }, i),
            s = parseFloat(s),
            !t.isNumeric(s))
                return !1;
            var n = function (t, e) {
                var a = Math.pow(10, e);
                t *= a;
                var i = t > 0 | -(0 > t)
                  , r = t % 1 === .5 * i;
                return r ? (Math.floor(t) + (i > 0)) / a : Math.round(t) / a
            }
              , o = function (t, e) {
                  if (0 === e)
                      return 1;
                  var a = (t + "").split(".")
                    , i = (e + "").split(".")
                    , r = (1 === a.length ? 0 : a[1].length) + (1 === i.length ? 0 : i[1].length);
                  return n(t - e * Math.floor(t / e), r)
              }
              , l = e.getLocale()
              , d = o(s - i.baseValue, i.step);
            return {
                valid: 0 === d || d === i.step,
                message: FormValidation.Helper.format(i.message || FormValidation.I18n[l].step["default"], [i.step])
            }
        }
    }
}(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            stringCase: {
                "default": "Please enter only lowercase characters",
                upper: "Please enter only uppercase characters"
            }
        }
    }),
    FormValidation.Validator.stringCase = {
        html5Attributes: {
            message: "message",
            "case": "case"
        },
        validate: function (t, e, a, i) {
            var r = t.getFieldValue(e, i);
            if ("" === r)
                return !0;
            var s = t.getLocale()
              , n = (a["case"] || "lower").toLowerCase();
            return {
                valid: "upper" === n ? r === r.toUpperCase() : r === r.toLowerCase(),
                message: a.message || ("upper" === n ? FormValidation.I18n[s].stringCase.upper : FormValidation.I18n[s].stringCase["default"])
            }
        }
    }
}
(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            stringLength: {
                "default": "Please enter a value with valid length",
                less: "Please enter less than %s characters",
                more: "Please enter more than %s characters",
                between: "Please enter value between %s and %s characters long"
            }
        }
    }),
    FormValidation.Validator.stringLength = {
        html5Attributes: {
            message: "message",
            min: "min",
            max: "max",
            trim: "trim",
            utf8bytes: "utf8Bytes"
        },
        enableByHtml5: function (e) {
            var a = {}
              , i = e.attr("maxlength")
              , r = e.attr("minlength");
            return i && (a.max = parseInt(i, 10)),
            r && (a.min = parseInt(r, 10)),
            t.isEmptyObject(a) ? !1 : a
        },
        validate: function (e, a, i, r) {
            var s = e.getFieldValue(a, r);
            if ((i.trim === !0 || "true" === i.trim) && (s = t.trim(s)),
            "" === s)
                return !0;
            var n = e.getLocale()
              , o = t.isNumeric(i.min) ? i.min : e.getDynamicOption(a, i.min)
              , l = t.isNumeric(i.max) ? i.max : e.getDynamicOption(a, i.max)
              , d = function (t) {
                  for (var e = t.length, a = t.length - 1; a >= 0; a--) {
                      var i = t.charCodeAt(a);
                      i > 127 && 2047 >= i ? e++ : i > 2047 && 65535 >= i && (e += 2),
                      i >= 56320 && 57343 >= i && a--
                  }
                  return e
              }
              , u = i.utf8Bytes ? d(s) : s.length
              , f = !0
              , c = i.message || FormValidation.I18n[n].stringLength["default"];
            switch ((o && u < parseInt(o, 10) || l && u > parseInt(l, 10)) && (f = !1),
            !0) {
                case !!o && !!l:
                    c = FormValidation.Helper.format(i.message || FormValidation.I18n[n].stringLength.between, [parseInt(o, 10), parseInt(l, 10)]);
                    break;
                case !!o:
                    c = FormValidation.Helper.format(i.message || FormValidation.I18n[n].stringLength.more, parseInt(o, 10) - 1);
                    break;
                case !!l:
                    c = FormValidation.Helper.format(i.message || FormValidation.I18n[n].stringLength.less, parseInt(l, 10) + 1)
            }
            return {
                valid: f,
                message: c
            }
        }
    }
}
(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            uri: {
                "default": "Please enter a valid URI"
            }
        }
    }),
    FormValidation.Validator.uri = {
        html5Attributes: {
            message: "message",
            allowlocal: "allowLocal",
            allowemptyprotocol: "allowEmptyProtocol",
            protocol: "protocol"
        },
        enableByHtml5: function (t) {
            return "url" === t.attr("type")
        },
        validate: function (t, e, a, i) {
            var r = t.getFieldValue(e, i);
            if ("" === r)
                return !0;
            var s = a.allowLocal === !0 || "true" === a.allowLocal
              , n = a.allowEmptyProtocol === !0 || "true" === a.allowEmptyProtocol
              , o = (a.protocol || "http, https, ftp").split(",").join("|").replace(/\s/g, "")
              , l = new RegExp("^(?:(?:" + o + ")://)" + (n ? "?" : "") + "(?:\\S+(?::\\S*)?@)?(?:" + (s ? "" : "(?!(?:10|127)(?:\\.\\d{1,3}){3})(?!(?:169\\.254|192\\.168)(?:\\.\\d{1,3}){2})(?!172\\.(?:1[6-9]|2\\d|3[0-1])(?:\\.\\d{1,3}){2})") + "(?:[1-9]\\d?|1\\d\\d|2[01]\\d|22[0-3])(?:\\.(?:1?\\d{1,2}|2[0-4]\\d|25[0-5])){2}(?:\\.(?:[1-9]\\d?|1\\d\\d|2[0-4]\\d|25[0-4]))|(?:(?:[a-z\\u00a1-\\uffff0-9]-?)*[a-z\\u00a1-\\uffff0-9]+)(?:\\.(?:[a-z\\u00a1-\\uffff0-9]-?)*[a-z\\u00a1-\\uffff0-9])*(?:\\.(?:[a-z\\u00a1-\\uffff]{2,}))" + (s ? "?" : "") + ")(?::\\d{2,5})?(?:/[^\\s]*)?$", "i");
            return l.test(r)
        }
    }
}
(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            uuid: {
                "default": "Please enter a valid UUID number",
                version: "Please enter a valid UUID version %s number"
            }
        }
    }),
    FormValidation.Validator.uuid = {
        html5Attributes: {
            message: "message",
            version: "version"
        },
        validate: function (t, e, a, i) {
            var r = t.getFieldValue(e, i);
            if ("" === r)
                return !0;
            var s = t.getLocale()
              , n = {
                  3: /^[0-9A-F]{8}-[0-9A-F]{4}-3[0-9A-F]{3}-[0-9A-F]{4}-[0-9A-F]{12}$/i,
                  4: /^[0-9A-F]{8}-[0-9A-F]{4}-4[0-9A-F]{3}-[89AB][0-9A-F]{3}-[0-9A-F]{12}$/i,
                  5: /^[0-9A-F]{8}-[0-9A-F]{4}-5[0-9A-F]{3}-[89AB][0-9A-F]{3}-[0-9A-F]{12}$/i,
                  all: /^[0-9A-F]{8}-[0-9A-F]{4}-[0-9A-F]{4}-[0-9A-F]{4}-[0-9A-F]{12}$/i
              }
              , o = a.version ? a.version + "" : "all";
            return {
                valid: null === n[o] ? !0 : n[o].test(r),
                message: a.version ? FormValidation.Helper.format(a.message || FormValidation.I18n[s].uuid.version, a.version) : a.message || FormValidation.I18n[s].uuid["default"]
            }
        }
    }
}
(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            vat: {
                "default": "Please enter a valid VAT number",
                country: "Please enter a valid VAT number in %s",
                countries: {
                    AT: "Austria",
                    BE: "Belgium",
                    BG: "Bulgaria",
                    BR: "Brazil",
                    CH: "Switzerland",
                    CY: "Cyprus",
                    CZ: "Czech Republic",
                    DE: "Germany",
                    DK: "Denmark",
                    EE: "Estonia",
                    ES: "Spain",
                    FI: "Finland",
                    FR: "France",
                    GB: "United Kingdom",
                    GR: "Greek",
                    EL: "Greek",
                    HU: "Hungary",
                    HR: "Croatia",
                    IE: "Ireland",
                    IS: "Iceland",
                    IT: "Italy",
                    LT: "Lithuania",
                    LU: "Luxembourg",
                    LV: "Latvia",
                    MT: "Malta",
                    NL: "Netherlands",
                    NO: "Norway",
                    PL: "Poland",
                    PT: "Portugal",
                    RO: "Romania",
                    RU: "Russia",
                    RS: "Serbia",
                    SE: "Sweden",
                    SI: "Slovenia",
                    SK: "Slovakia",
                    VE: "Venezuela",
                    ZA: "South Africa"
                }
            }
        }
    }),
    FormValidation.Validator.vat = {
        html5Attributes: {
            message: "message",
            country: "country"
        },
        COUNTRY_CODES: ["AT", "BE", "BG", "BR", "CH", "CY", "CZ", "DE", "DK", "EE", "EL", "ES", "FI", "FR", "GB", "GR", "HR", "HU", "IE", "IS", "IT", "LT", "LU", "LV", "MT", "NL", "NO", "PL", "PT", "RO", "RU", "RS", "SE", "SK", "SI", "VE", "ZA"],
        validate: function (e, a, i, r) {
            var s = e.getFieldValue(a, r);
            if ("" === s)
                return !0;
            var n = e.getLocale()
              , o = i.country;
            if (o ? ("string" != typeof o || -1 === t.inArray(o.toUpperCase(), this.COUNTRY_CODES)) && (o = e.getDynamicOption(a, o)) : o = s.substr(0, 2),
            -1 === t.inArray(o, this.COUNTRY_CODES))
                return !0;
            var l = ["_", o.toLowerCase()].join("")
              , d = this[l](s);
            return d = d === !0 || d === !1 ? {
                valid: d
            } : d,
            d.message = FormValidation.Helper.format(i.message || FormValidation.I18n[n].vat.country, FormValidation.I18n[n].vat.countries[o.toUpperCase()]),
            d
        },
        _at: function (t) {
            if (/^ATU[0-9]{8}$/.test(t) && (t = t.substr(2)),
            !/^U[0-9]{8}$/.test(t))
                return !1;
            t = t.substr(1);
            for (var e = 0, a = [1, 2, 1, 2, 1, 2, 1], i = 0, r = 0; 7 > r; r++)
                i = parseInt(t.charAt(r), 10) * a[r],
                i > 9 && (i = Math.floor(i / 10) + i % 10),
                e += i;
            return e = 10 - (e + 4) % 10,
            10 === e && (e = 0),
            e + "" === t.substr(7, 1)
        },
        _be: function (t) {
            if (/^BE[0]{0,1}[0-9]{9}$/.test(t) && (t = t.substr(2)),
            !/^[0]{0,1}[0-9]{9}$/.test(t))
                return !1;
            if (9 === t.length && (t = "0" + t),
            "0" === t.substr(1, 1))
                return !1;
            var e = parseInt(t.substr(0, 8), 10) + parseInt(t.substr(8, 2), 10);
            return e % 97 === 0
        },
        _bg: function (t) {
            if (/^BG[0-9]{9,10}$/.test(t) && (t = t.substr(2)),
            !/^[0-9]{9,10}$/.test(t))
                return !1;
            var e = 0
              , a = 0;
            if (9 === t.length) {
                for (a = 0; 8 > a; a++)
                    e += parseInt(t.charAt(a), 10) * (a + 1);
                if (e %= 11,
                10 === e)
                    for (e = 0,
                    a = 0; 8 > a; a++)
                        e += parseInt(t.charAt(a), 10) * (a + 3);
                return e %= 10,
                e + "" === t.substr(8)
            }
            if (10 === t.length) {
                var i = function (t) {
                    var e = parseInt(t.substr(0, 2), 10) + 1900
                      , a = parseInt(t.substr(2, 2), 10)
                      , i = parseInt(t.substr(4, 2), 10);
                    if (a > 40 ? (e += 100,
                    a -= 40) : a > 20 && (e -= 100,
                    a -= 20),
                    !FormValidation.Helper.date(e, a, i))
                        return !1;
                    for (var r = 0, s = [2, 4, 8, 5, 10, 9, 7, 3, 6], n = 0; 9 > n; n++)
                        r += parseInt(t.charAt(n), 10) * s[n];
                    return r = r % 11 % 10,
                    r + "" === t.substr(9, 1)
                }
                  , r = function (t) {
                      for (var e = 0, a = [21, 19, 17, 13, 11, 9, 7, 3, 1], i = 0; 9 > i; i++)
                          e += parseInt(t.charAt(i), 10) * a[i];
                      return e %= 10,
                      e + "" === t.substr(9, 1)
                  }
                  , s = function (t) {
                      for (var e = 0, a = [4, 3, 2, 7, 6, 5, 4, 3, 2], i = 0; 9 > i; i++)
                          e += parseInt(t.charAt(i), 10) * a[i];
                      return e = 11 - e % 11,
                      10 === e ? !1 : (11 === e && (e = 0),
                      e + "" === t.substr(9, 1))
                  }
                ;
                return i(t) || r(t) || s(t)
            }
            return !1
        },
        _br: function (t) {
            if ("" === t)
                return !0;
            var e = t.replace(/[^\d]+/g, "");
            if ("" === e || 14 !== e.length)
                return !1;
            if ("00000000000000" === e || "11111111111111" === e || "22222222222222" === e || "33333333333333" === e || "44444444444444" === e || "55555555555555" === e || "66666666666666" === e || "77777777777777" === e || "88888888888888" === e || "99999999999999" === e)
                return !1;
            for (var a = e.length - 2, i = e.substring(0, a), r = e.substring(a), s = 0, n = a - 7, o = a; o >= 1; o--)
                s += parseInt(i.charAt(a - o), 10) * n--,
                2 > n && (n = 9);
            var l = 2 > s % 11 ? 0 : 11 - s % 11;
            if (l !== parseInt(r.charAt(0), 10))
                return !1;
            for (a += 1,
            i = e.substring(0, a),
            s = 0,
            n = a - 7,
            o = a; o >= 1; o--)
                s += parseInt(i.charAt(a - o), 10) * n--,
                2 > n && (n = 9);
            return l = 2 > s % 11 ? 0 : 11 - s % 11,
            l === parseInt(r.charAt(1), 10)
        },
        _ch: function (t) {
            if (/^CHE[0-9]{9}(MWST)?$/.test(t) && (t = t.substr(2)),
            !/^E[0-9]{9}(MWST)?$/.test(t))
                return !1;
            t = t.substr(1);
            for (var e = 0, a = [5, 4, 3, 2, 7, 6, 5, 4], i = 0; 8 > i; i++)
                e += parseInt(t.charAt(i), 10) * a[i];
            return e = 11 - e % 11,
            10 === e ? !1 : (11 === e && (e = 0),
            e + "" === t.substr(8, 1))
        },
        _cy: function (t) {
            if (/^CY[0-5|9]{1}[0-9]{7}[A-Z]{1}$/.test(t) && (t = t.substr(2)),
            !/^[0-5|9]{1}[0-9]{7}[A-Z]{1}$/.test(t))
                return !1;
            if ("12" === t.substr(0, 2))
                return !1;
            for (var e = 0, a = {
                0: 1,
                1: 0,
                2: 5,
                3: 7,
                4: 9,
                5: 13,
                6: 15,
                7: 17,
                8: 19,
                9: 21
            }, i = 0; 8 > i; i++) {
                var r = parseInt(t.charAt(i), 10);
                i % 2 === 0 && (r = a[r + ""]),
                e += r
            }
            return e = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"[e % 26],
            e + "" === t.substr(8, 1)
        },
        _cz: function (t) {
            if (/^CZ[0-9]{8,10}$/.test(t) && (t = t.substr(2)),
            !/^[0-9]{8,10}$/.test(t))
                return !1;
            var e = 0
              , a = 0;
            if (8 === t.length) {
                if (t.charAt(0) + "" == "9")
                    return !1;
                for (e = 0,
                a = 0; 7 > a; a++)
                    e += parseInt(t.charAt(a), 10) * (8 - a);
                return e = 11 - e % 11,
                10 === e && (e = 0),
                11 === e && (e = 1),
                e + "" === t.substr(7, 1)
            }
            if (9 === t.length && t.charAt(0) + "" == "6") {
                for (e = 0,
                a = 0; 7 > a; a++)
                    e += parseInt(t.charAt(a + 1), 10) * (8 - a);
                return e = 11 - e % 11,
                10 === e && (e = 0),
                11 === e && (e = 1),
                e = [8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 10][e - 1],
                e + "" === t.substr(8, 1)
            }
            if (9 === t.length || 10 === t.length) {
                var i = 1900 + parseInt(t.substr(0, 2), 10)
                  , r = parseInt(t.substr(2, 2), 10) % 50 % 20
                  , s = parseInt(t.substr(4, 2), 10);
                if (9 === t.length) {
                    if (i >= 1980 && (i -= 100),
                    i > 1953)
                        return !1
                } else
                    1954 > i && (i += 100);
                if (!FormValidation.Helper.date(i, r, s))
                    return !1;
                if (10 === t.length) {
                    var n = parseInt(t.substr(0, 9), 10) % 11;
                    return 1985 > i && (n %= 10),
                    n + "" === t.substr(9, 1)
                }
                return !0
            }
            return !1
        },
        _de: function (t) {
            return /^DE[0-9]{9}$/.test(t) && (t = t.substr(2)),
            /^[0-9]{9}$/.test(t) ? FormValidation.Helper.mod11And10(t) : !1
        },
        _dk: function (t) {
            if (/^DK[0-9]{8}$/.test(t) && (t = t.substr(2)),
            !/^[0-9]{8}$/.test(t))
                return !1;
            for (var e = 0, a = [2, 7, 6, 5, 4, 3, 2, 1], i = 0; 8 > i; i++)
                e += parseInt(t.charAt(i), 10) * a[i];
            return e % 11 === 0
        },
        _ee: function (t) {
            if (/^EE[0-9]{9}$/.test(t) && (t = t.substr(2)),
            !/^[0-9]{9}$/.test(t))
                return !1;
            for (var e = 0, a = [3, 7, 1, 3, 7, 1, 3, 7, 1], i = 0; 9 > i; i++)
                e += parseInt(t.charAt(i), 10) * a[i];
            return e % 10 === 0
        },
        _es: function (t) {
            if (/^ES[0-9A-Z][0-9]{7}[0-9A-Z]$/.test(t) && (t = t.substr(2)),
            !/^[0-9A-Z][0-9]{7}[0-9A-Z]$/.test(t))
                return !1;
            var e = function (t) {
                var e = parseInt(t.substr(0, 8), 10);
                return e = "TRWAGMYFPDXBNJZSQVHLCKE"[e % 23],
                e + "" === t.substr(8, 1)
            }
              , a = function (t) {
                  var e = ["XYZ".indexOf(t.charAt(0)), t.substr(1)].join("");
                  return e = parseInt(e, 10),
                  e = "TRWAGMYFPDXBNJZSQVHLCKE"[e % 23],
                  e + "" === t.substr(8, 1)
              }
              , i = function (t) {
                  var e, a = t.charAt(0);
                  if (-1 !== "KLM".indexOf(a))
                      return e = parseInt(t.substr(1, 8), 10),
                      e = "TRWAGMYFPDXBNJZSQVHLCKE"[e % 23],
                      e + "" === t.substr(8, 1);
                  if (-1 !== "ABCDEFGHJNPQRSUVW".indexOf(a)) {
                      for (var i = 0, r = [2, 1, 2, 1, 2, 1, 2], s = 0, n = 0; 7 > n; n++)
                          s = parseInt(t.charAt(n + 1), 10) * r[n],
                          s > 9 && (s = Math.floor(s / 10) + s % 10),
                          i += s;
                      return i = 10 - i % 10,
                      10 === i && (i = 0),
                      i + "" === t.substr(8, 1) || "JABCDEFGHI"[i] === t.substr(8, 1)
                  }
                  return !1
              }
              , r = t.charAt(0);
            return /^[0-9]$/.test(r) ? {
                valid: e(t),
                type: "DNI"
            } : /^[XYZ]$/.test(r) ? {
                valid: a(t),
                type: "NIE"
            } : {
                valid: i(t),
                type: "CIF"
            }
        },
        _fi: function (t) {
            if (/^FI[0-9]{8}$/.test(t) && (t = t.substr(2)),
            !/^[0-9]{8}$/.test(t))
                return !1;
            for (var e = 0, a = [7, 9, 10, 5, 8, 4, 2, 1], i = 0; 8 > i; i++)
                e += parseInt(t.charAt(i), 10) * a[i];
            return e % 11 === 0
        },
        _fr: function (t) {
            if (/^FR[0-9A-Z]{2}[0-9]{9}$/.test(t) && (t = t.substr(2)),
            !/^[0-9A-Z]{2}[0-9]{9}$/.test(t))
                return !1;
            if (!FormValidation.Helper.luhn(t.substr(2)))
                return !1;
            if (/^[0-9]{2}$/.test(t.substr(0, 2)))
                return t.substr(0, 2) === parseInt(t.substr(2) + "12", 10) % 97 + "";
            var e, a = "0123456789ABCDEFGHJKLMNPQRSTUVWXYZ";
            return e = /^[0-9]{1}$/.test(t.charAt(0)) ? 24 * a.indexOf(t.charAt(0)) + a.indexOf(t.charAt(1)) - 10 : 34 * a.indexOf(t.charAt(0)) + a.indexOf(t.charAt(1)) - 100,
            (parseInt(t.substr(2), 10) + 1 + Math.floor(e / 11)) % 11 === e % 11
        },
        _gb: function (t) {
            if ((/^GB[0-9]{9}$/.test(t) || /^GB[0-9]{12}$/.test(t) || /^GBGD[0-9]{3}$/.test(t) || /^GBHA[0-9]{3}$/.test(t) || /^GB(GD|HA)8888[0-9]{5}$/.test(t)) && (t = t.substr(2)),
            !(/^[0-9]{9}$/.test(t) || /^[0-9]{12}$/.test(t) || /^GD[0-9]{3}$/.test(t) || /^HA[0-9]{3}$/.test(t) || /^(GD|HA)8888[0-9]{5}$/.test(t)))
                return !1;
            var e = t.length;
            if (5 === e) {
                var a = t.substr(0, 2)
                  , i = parseInt(t.substr(2), 10);
                return "GD" === a && 500 > i || "HA" === a && i >= 500
            }
            if (11 === e && ("GD8888" === t.substr(0, 6) || "HA8888" === t.substr(0, 6)))
                return "GD" === t.substr(0, 2) && parseInt(t.substr(6, 3), 10) >= 500 || "HA" === t.substr(0, 2) && parseInt(t.substr(6, 3), 10) < 500 ? !1 : parseInt(t.substr(6, 3), 10) % 97 === parseInt(t.substr(9, 2), 10);
            if (9 === e || 12 === e) {
                for (var r = 0, s = [8, 7, 6, 5, 4, 3, 2, 10, 1], n = 0; 9 > n; n++)
                    r += parseInt(t.charAt(n), 10) * s[n];
                return r %= 97,
                parseInt(t.substr(0, 3), 10) >= 100 ? 0 === r || 42 === r || 55 === r : 0 === r
            }
            return !0
        },
        _gr: function (t) {
            if (/^(GR|EL)[0-9]{9}$/.test(t) && (t = t.substr(2)),
            !/^[0-9]{9}$/.test(t))
                return !1;
            8 === t.length && (t = "0" + t);
            for (var e = 0, a = [256, 128, 64, 32, 16, 8, 4, 2], i = 0; 8 > i; i++)
                e += parseInt(t.charAt(i), 10) * a[i];
            return e = e % 11 % 10,
            e + "" === t.substr(8, 1)
        },
        _el: function (t) {
            return this._gr(t)
        },
        _hu: function (t) {
            if (/^HU[0-9]{8}$/.test(t) && (t = t.substr(2)),
            !/^[0-9]{8}$/.test(t))
                return !1;
            for (var e = 0, a = [9, 7, 3, 1, 9, 7, 3, 1], i = 0; 8 > i; i++)
                e += parseInt(t.charAt(i), 10) * a[i];
            return e % 10 === 0
        },
        _hr: function (t) {
            return /^HR[0-9]{11}$/.test(t) && (t = t.substr(2)),
            /^[0-9]{11}$/.test(t) ? FormValidation.Helper.mod11And10(t) : !1
        },
        _ie: function (t) {
            if (/^IE[0-9]{1}[0-9A-Z\*\+]{1}[0-9]{5}[A-Z]{1,2}$/.test(t) && (t = t.substr(2)),
            !/^[0-9]{1}[0-9A-Z\*\+]{1}[0-9]{5}[A-Z]{1,2}$/.test(t))
                return !1;
            var e = function (t) {
                for (; t.length < 7;)
                    t = "0" + t;
                for (var e = "WABCDEFGHIJKLMNOPQRSTUV", a = 0, i = 0; 7 > i; i++)
                    a += parseInt(t.charAt(i), 10) * (8 - i);
                return a += 9 * e.indexOf(t.substr(7)),
                e[a % 23]
            }
            ;
            return /^[0-9]+$/.test(t.substr(0, 7)) ? t.charAt(7) === e(t.substr(0, 7) + t.substr(8) + "") : -1 !== "ABCDEFGHIJKLMNOPQRSTUVWXYZ+*".indexOf(t.charAt(1)) ? t.charAt(7) === e(t.substr(2, 5) + t.substr(0, 1) + "") : !0
        },
        _is: function (t) {
            return /^IS[0-9]{5,6}$/.test(t) && (t = t.substr(2)),
            /^[0-9]{5,6}$/.test(t)
        },
        _it: function (t) {
            if (/^IT[0-9]{11}$/.test(t) && (t = t.substr(2)),
            !/^[0-9]{11}$/.test(t))
                return !1;
            if (0 === parseInt(t.substr(0, 7), 10))
                return !1;
            var e = parseInt(t.substr(7, 3), 10);
            return 1 > e || e > 201 && 999 !== e && 888 !== e ? !1 : FormValidation.Helper.luhn(t)
        },
        _lt: function (t) {
            if (/^LT([0-9]{7}1[0-9]{1}|[0-9]{10}1[0-9]{1})$/.test(t) && (t = t.substr(2)),
            !/^([0-9]{7}1[0-9]{1}|[0-9]{10}1[0-9]{1})$/.test(t))
                return !1;
            var e, a = t.length, i = 0;
            for (e = 0; a - 1 > e; e++)
                i += parseInt(t.charAt(e), 10) * (1 + e % 9);
            var r = i % 11;
            if (10 === r)
                for (i = 0,
                e = 0; a - 1 > e; e++)
                    i += parseInt(t.charAt(e), 10) * (1 + (e + 2) % 9);
            return r = r % 11 % 10,
            r + "" === t.charAt(a - 1)
        },
        _lu: function (t) {
            return /^LU[0-9]{8}$/.test(t) && (t = t.substr(2)),
            /^[0-9]{8}$/.test(t) ? parseInt(t.substr(0, 6), 10) % 89 + "" === t.substr(6, 2) : !1
        },
        _lv: function (t) {
            if (/^LV[0-9]{11}$/.test(t) && (t = t.substr(2)),
            !/^[0-9]{11}$/.test(t))
                return !1;
            var e, a = parseInt(t.charAt(0), 10), i = 0, r = [], s = t.length;
            if (a > 3) {
                for (i = 0,
                r = [9, 1, 4, 8, 3, 10, 2, 5, 7, 6, 1],
                e = 0; s > e; e++)
                    i += parseInt(t.charAt(e), 10) * r[e];
                return i %= 11,
                3 === i
            }
            var n = parseInt(t.substr(0, 2), 10)
              , o = parseInt(t.substr(2, 2), 10)
              , l = parseInt(t.substr(4, 2), 10);
            if (l = l + 1800 + 100 * parseInt(t.charAt(6), 10),
            !FormValidation.Helper.date(l, o, n))
                return !1;
            for (i = 0,
            r = [10, 5, 8, 4, 2, 1, 6, 3, 7, 9],
            e = 0; s - 1 > e; e++)
                i += parseInt(t.charAt(e), 10) * r[e];
            return i = (i + 1) % 11 % 10,
            i + "" === t.charAt(s - 1)
        },
        _mt: function (t) {
            if (/^MT[0-9]{8}$/.test(t) && (t = t.substr(2)),
            !/^[0-9]{8}$/.test(t))
                return !1;
            for (var e = 0, a = [3, 4, 6, 7, 8, 9, 10, 1], i = 0; 8 > i; i++)
                e += parseInt(t.charAt(i), 10) * a[i];
            return e % 37 === 0
        },
        _nl: function (t) {
            if (/^NL[0-9]{9}B[0-9]{2}$/.test(t) && (t = t.substr(2)),
            !/^[0-9]{9}B[0-9]{2}$/.test(t))
                return !1;
            for (var e = 0, a = [9, 8, 7, 6, 5, 4, 3, 2], i = 0; 8 > i; i++)
                e += parseInt(t.charAt(i), 10) * a[i];
            return e %= 11,
            e > 9 && (e = 0),
            e + "" === t.substr(8, 1)
        },
        _no: function (t) {
            if (/^NO[0-9]{9}$/.test(t) && (t = t.substr(2)),
            !/^[0-9]{9}$/.test(t))
                return !1;
            for (var e = 0, a = [3, 2, 7, 6, 5, 4, 3, 2], i = 0; 8 > i; i++)
                e += parseInt(t.charAt(i), 10) * a[i];
            return e = 11 - e % 11,
            11 === e && (e = 0),
            e + "" === t.substr(8, 1)
        },
        _pl: function (t) {
            if (/^PL[0-9]{10}$/.test(t) && (t = t.substr(2)),
            !/^[0-9]{10}$/.test(t))
                return !1;
            for (var e = 0, a = [6, 5, 7, 2, 3, 4, 5, 6, 7, -1], i = 0; 10 > i; i++)
                e += parseInt(t.charAt(i), 10) * a[i];
            return e % 11 === 0
        },
        _pt: function (t) {
            if (/^PT[0-9]{9}$/.test(t) && (t = t.substr(2)),
            !/^[0-9]{9}$/.test(t))
                return !1;
            for (var e = 0, a = [9, 8, 7, 6, 5, 4, 3, 2], i = 0; 8 > i; i++)
                e += parseInt(t.charAt(i), 10) * a[i];
            return e = 11 - e % 11,
            e > 9 && (e = 0),
            e + "" === t.substr(8, 1)
        },
        _ro: function (t) {
            if (/^RO[1-9][0-9]{1,9}$/.test(t) && (t = t.substr(2)),
            !/^[1-9][0-9]{1,9}$/.test(t))
                return !1;
            for (var e = t.length, a = [7, 5, 3, 2, 1, 7, 5, 3, 2].slice(10 - e), i = 0, r = 0; e - 1 > r; r++)
                i += parseInt(t.charAt(r), 10) * a[r];
            return i = 10 * i % 11 % 10,
            i + "" === t.substr(e - 1, 1)
        },
        _ru: function (t) {
            if (/^RU([0-9]{10}|[0-9]{12})$/.test(t) && (t = t.substr(2)),
            !/^([0-9]{10}|[0-9]{12})$/.test(t))
                return !1;
            var e = 0;
            if (10 === t.length) {
                var a = 0
                  , i = [2, 4, 10, 3, 5, 9, 4, 6, 8, 0];
                for (e = 0; 10 > e; e++)
                    a += parseInt(t.charAt(e), 10) * i[e];
                return a %= 11,
                a > 9 && (a %= 10),
                a + "" === t.substr(9, 1)
            }
            if (12 === t.length) {
                var r = 0
                  , s = [7, 2, 4, 10, 3, 5, 9, 4, 6, 8, 0]
                  , n = 0
                  , o = [3, 7, 2, 4, 10, 3, 5, 9, 4, 6, 8, 0];
                for (e = 0; 11 > e; e++)
                    r += parseInt(t.charAt(e), 10) * s[e],
                    n += parseInt(t.charAt(e), 10) * o[e];
                return r %= 11,
                r > 9 && (r %= 10),
                n %= 11,
                n > 9 && (n %= 10),
                r + "" === t.substr(10, 1) && n + "" === t.substr(11, 1)
            }
            return !1
        },
        _rs: function (t) {
            if (/^RS[0-9]{9}$/.test(t) && (t = t.substr(2)),
            !/^[0-9]{9}$/.test(t))
                return !1;
            for (var e = 10, a = 0, i = 0; 8 > i; i++)
                a = (parseInt(t.charAt(i), 10) + e) % 10,
                0 === a && (a = 10),
                e = 2 * a % 11;
            return (e + parseInt(t.substr(8, 1), 10)) % 10 === 1
        },
        _se: function (t) {
            return /^SE[0-9]{10}01$/.test(t) && (t = t.substr(2)),
            /^[0-9]{10}01$/.test(t) ? (t = t.substr(0, 10),
            FormValidation.Helper.luhn(t)) : !1
        },
        _si: function (t) {
            var e = t.match(/^(SI)?([1-9][0-9]{7})$/);
            if (!e)
                return !1;
            e[1] && (t = t.substr(2));
            for (var a = 0, i = [8, 7, 6, 5, 4, 3, 2], r = 0; 7 > r; r++)
                a += parseInt(t.charAt(r), 10) * i[r];
            return a = 11 - a % 11,
            10 === a && (a = 0),
            a + "" === t.substr(7, 1)
        },
        _sk: function (t) {
            return /^SK[1-9][0-9][(2-4)|(6-9)][0-9]{7}$/.test(t) && (t = t.substr(2)),
            /^[1-9][0-9][(2-4)|(6-9)][0-9]{7}$/.test(t) ? parseInt(t, 10) % 11 === 0 : !1
        },
        _ve: function (t) {
            if (/^VE[VEJPG][0-9]{9}$/.test(t) && (t = t.substr(2)),
            !/^[VEJPG][0-9]{9}$/.test(t))
                return !1;
            for (var e = {
                V: 4,
                E: 8,
                J: 12,
                P: 16,
                G: 20
            }, a = e[t.charAt(0)], i = [3, 2, 7, 6, 5, 4, 3, 2], r = 0; 8 > r; r++)
                a += parseInt(t.charAt(r + 1), 10) * i[r];
            return a = 11 - a % 11,
            (11 === a || 10 === a) && (a = 0),
            a + "" === t.substr(9, 1)
        },
        _za: function (t) {
            return /^ZA4[0-9]{9}$/.test(t) && (t = t.substr(2)),
            /^4[0-9]{9}$/.test(t)
        }
    }
}
(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            vin: {
                "default": "Please enter a valid VIN number"
            }
        }
    }),
    FormValidation.Validator.vin = {
        validate: function (t, e, a, i) {
            var r = t.getFieldValue(e, i);
            if ("" === r)
                return !0;
            if (!/^[a-hj-npr-z0-9]{8}[0-9xX][a-hj-npr-z0-9]{8}$/i.test(r))
                return !1;
            r = r.toUpperCase();
            for (var s = {
                A: 1,
                B: 2,
                C: 3,
                D: 4,
                E: 5,
                F: 6,
                G: 7,
                H: 8,
                J: 1,
                K: 2,
                L: 3,
                M: 4,
                N: 5,
                P: 7,
                R: 9,
                S: 2,
                T: 3,
                U: 4,
                V: 5,
                W: 6,
                X: 7,
                Y: 8,
                Z: 9,
                1: 1,
                2: 2,
                3: 3,
                4: 4,
                5: 5,
                6: 6,
                7: 7,
                8: 8,
                9: 9,
                0: 0
            }, n = [8, 7, 6, 5, 4, 3, 2, 10, 0, 9, 8, 7, 6, 5, 4, 3, 2], o = 0, l = r.length, d = 0; l > d; d++)
                o += s[r.charAt(d) + ""] * n[d];
            var u = o % 11;
            return 10 === u && (u = "X"),
            u + "" === r.charAt(8)
        }
    }
}(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n || {}, {
        en_US: {
            zipCode: {
                "default": "Please enter a valid postal code",
                country: "Please enter a valid postal code in %s",
                countries: {
                    AT: "Austria",
                    BG: "Bulgaria",
                    BR: "Brazil",
                    CA: "Canada",
                    CH: "Switzerland",
                    CZ: "Czech Republic",
                    DE: "Germany",
                    DK: "Denmark",
                    ES: "Spain",
                    FR: "France",
                    GB: "United Kingdom",
                    IE: "Ireland",
                    IN: "India",
                    IT: "Italy",
                    MA: "Morocco",
                    NL: "Netherlands",
                    PL: "Poland",
                    PT: "Portugal",
                    RO: "Romania",
                    RU: "Russia",
                    SE: "Sweden",
                    SG: "Singapore",
                    SK: "Slovakia",
                    US: "USA"
                }
            }
        }
    }),
    FormValidation.Validator.zipCode = {
        html5Attributes: {
            message: "message",
            country: "country"
        },
        COUNTRY_CODES: ["AT", "BG", "BR", "CA", "CH", "CZ", "DE", "DK", "ES", "FR", "GB", "IE", "IN", "IT", "MA", "NL", "PL", "PT", "RO", "RU", "SE", "SG", "SK", "US"],
        validate: function (e, a, i, r) {
            var s = e.getFieldValue(a, r);
            if ("" === s || !i.country)
                return !0;
            var n = e.getLocale()
              , o = i.country;
            if (("string" != typeof o || -1 === t.inArray(o, this.COUNTRY_CODES)) && (o = e.getDynamicOption(a, o)),
            !o || -1 === t.inArray(o.toUpperCase(), this.COUNTRY_CODES))
                return !0;
            var l = !1;
            switch (o = o.toUpperCase()) {
                case "AT":
                    l = /^([1-9]{1})(\d{3})$/.test(s);
                    break;
                case "BG":
                    l = /^([1-9]{1}[0-9]{3})$/.test(t.trim(s));
                    break;
                case "BR":
                    l = /^(\d{2})([\.]?)(\d{3})([\-]?)(\d{3})$/.test(s);
                    break;
                case "CA":
                    l = /^(?:A|B|C|E|G|H|J|K|L|M|N|P|R|S|T|V|X|Y){1}[0-9]{1}(?:A|B|C|E|G|H|J|K|L|M|N|P|R|S|T|V|W|X|Y|Z){1}\s?[0-9]{1}(?:A|B|C|E|G|H|J|K|L|M|N|P|R|S|T|V|W|X|Y|Z){1}[0-9]{1}$/i.test(s);
                    break;
                case "CH":
                    l = /^([1-9]{1})(\d{3})$/.test(s);
                    break;
                case "CZ":
                    l = /^(\d{3})([ ]?)(\d{2})$/.test(s);
                    break;
                case "DE":
                    l = /^(?!01000|99999)(0[1-9]\d{3}|[1-9]\d{4})$/.test(s);
                    break;
                case "DK":
                    l = /^(DK(-|\s)?)?\d{4}$/i.test(s);
                    break;
                case "ES":
                    l = /^(?:0[1-9]|[1-4][0-9]|5[0-2])\d{3}$/.test(s);
                    break;
                case "FR":
                    l = /^[0-9]{5}$/i.test(s);
                    break;
                case "GB":
                    l = this._gb(s);
                    break;
                case "IN":
                    l = /^\d{3}\s?\d{3}$/.test(s);
                    break;
                case "IE":
                    l = /^(D6W|[ACDEFHKNPRTVWXY]\d{2})\s[0-9ACDEFHKNPRTVWXY]{4}$/.test(s);
                    break;
                case "IT":
                    l = /^(I-|IT-)?\d{5}$/i.test(s);
                    break;
                case "MA":
                    l = /^[1-9][0-9]{4}$/i.test(s);
                    break;
                case "NL":
                    l = /^[1-9][0-9]{3} ?(?!sa|sd|ss)[a-z]{2}$/i.test(s);
                    break;
                case "PL":
                    l = /^[0-9]{2}\-[0-9]{3}$/.test(s);
                    break;
                case "PT":
                    l = /^[1-9]\d{3}-\d{3}$/.test(s);
                    break;
                case "RO":
                    l = /^(0[1-8]{1}|[1-9]{1}[0-5]{1})?[0-9]{4}$/i.test(s);
                    break;
                case "RU":
                    l = /^[0-9]{6}$/i.test(s);
                    break;
                case "SE":
                    l = /^(S-)?\d{3}\s?\d{2}$/i.test(s);
                    break;
                case "SG":
                    l = /^([0][1-9]|[1-6][0-9]|[7]([0-3]|[5-9])|[8][0-2])(\d{4})$/i.test(s);
                    break;
                case "SK":
                    l = /^(\d{3})([ ]?)(\d{2})$/.test(s);
                    break;
                case "US":
                default:
                    l = /^\d{4,5}([\-]?\d{4})?$/.test(s)
            }
            return {
                valid: l,
                message: FormValidation.Helper.format(i.message || FormValidation.I18n[n].zipCode.country, FormValidation.I18n[n].zipCode.countries[o])
            }
        },
        _gb: function (t) {
            for (var e = "[ABCDEFGHIJKLMNOPRSTUWYZ]", a = "[ABCDEFGHKLMNOPQRSTUVWXY]", i = "[ABCDEFGHJKPMNRSTUVWXY]", r = "[ABEHMNPRVWXY]", s = "[ABDEFGHJLNPQRSTUWXYZ]", n = [new RegExp("^(" + e + "{1}" + a + "?[0-9]{1,2})(\\s*)([0-9]{1}" + s + "{2})$", "i"), new RegExp("^(" + e + "{1}[0-9]{1}" + i + "{1})(\\s*)([0-9]{1}" + s + "{2})$", "i"), new RegExp("^(" + e + "{1}" + a + "{1}?[0-9]{1}" + r + "{1})(\\s*)([0-9]{1}" + s + "{2})$", "i"), new RegExp("^(BF1)(\\s*)([0-6]{1}[ABDEFGHJLNPQRST]{1}[ABDEFGHJLNPQRSTUWZYZ]{1})$", "i"), /^(GIR)(\s*)(0AA)$/i, /^(BFPO)(\s*)([0-9]{1,4})$/i, /^(BFPO)(\s*)(c\/o\s*[0-9]{1,3})$/i, /^([A-Z]{4})(\s*)(1ZZ)$/i, /^(AI-2640)$/i], o = 0; o < n.length; o++)
                if (n[o].test(t))
                    return !0;
            return !1
        }
    }
}
(jQuery),
!function (t) {
    FormValidation.Framework.Bootstrap = function (e, a, i) {
        a = t.extend(!0, {
            button: {
                selector: '[type="submit"]:not([formnovalidate])',
                disabled: "disabled"
            },
            err: {
                clazz: "help-block",
                parent: "^(.*)col-(xs|sm|md|lg)-(offset-){0,1}[0-9]+(.*)$"
            },
            icon: {
                valid: null,
                invalid: null,
                validating: null,
                feedback: "form-control-feedback"
            },
            row: {
                selector: ".form-group",
                valid: "has-success",
                invalid: "has-error",
                feedback: "has-feedback"
            }
        }, a),
        FormValidation.Base.apply(this, [e, a, i])
    }
    ,
    FormValidation.Framework.Bootstrap.prototype = t.extend({}, FormValidation.Base.prototype, {
        _fixIcon: function (t, e) {
            var a = this._namespace
              , i = t.attr("type")
              , r = t.attr("data-" + a + "-field")
              , s = this.options.fields[r].row || this.options.row.selector
              , n = t.closest(s);
            if ("checkbox" === i || "radio" === i) {
                var o = t.parent();
                o.hasClass(i) ? e.insertAfter(o) : o.parent().hasClass(i) && e.insertAfter(o.parent())
            }
            0 === n.find("label").length && e.addClass("fv-icon-no-label"),
            0 !== n.find(".input-group").length && e.addClass("fv-bootstrap-icon-input-group").insertAfter(n.find(".input-group").eq(0))
        },
        _createTooltip: function (t, e, a) {
            var i = this._namespace
              , r = t.data(i + ".icon");
            if (r)
                switch (a) {
                    case "popover":
                        r.css({
                            cursor: "pointer",
                            "pointer-events": "auto"
                        }).popover("destroy").popover({
                            container: "body",
                            content: e,
                            html: !0,
                            placement: "auto top",
                            trigger: "hover click"
                        });
                        break;
                    case "tooltip":
                    default:
                        r.css({
                            cursor: "pointer",
                            "pointer-events": "auto"
                        }).tooltip("destroy").tooltip({
                            container: "body",
                            html: !0,
                            placement: "auto top",
                            title: e
                        })
                }
        },
        _destroyTooltip: function (t, e) {
            var a = this._namespace
              , i = t.data(a + ".icon");
            if (i)
                switch (e) {
                    case "popover":
                        i.css({
                            cursor: "",
                            "pointer-events": "none"
                        }).popover("destroy");
                        break;
                    case "tooltip":
                    default:
                        i.css({
                            cursor: "",
                            "pointer-events": "none"
                        }).tooltip("destroy")
                }
        },
        _hideTooltip: function (t, e) {
            var a = this._namespace
              , i = t.data(a + ".icon");
            if (i)
                switch (e) {
                    case "popover":
                        i.popover("hide");
                        break;
                    case "tooltip":
                    default:
                        i.tooltip("hide")
                }
        },
        _showTooltip: function (t, e) {
            var a = this._namespace
              , i = t.data(a + ".icon");
            if (i)
                switch (e) {
                    case "popover":
                        i.popover("show");
                        break;
                    case "tooltip":
                    default:
                        i.tooltip("show")
                }
        }
    }),
    t.fn.bootstrapValidator = function (e) {
        var a = arguments;
        return this.each(function () {
            var i = t(this)
              , r = i.data("formValidation") || i.data("bootstrapValidator")
              , s = "object" == typeof e && e;
            r || (r = new FormValidation.Framework.Bootstrap(this, t.extend({}, {
                events: {
                    formInit: "init.form.bv",
                    formPreValidate: "prevalidate.form.bv",
                    formError: "error.form.bv",
                    formSuccess: "success.form.bv",
                    fieldAdded: "added.field.bv",
                    fieldRemoved: "removed.field.bv",
                    fieldInit: "init.field.bv",
                    fieldError: "error.field.bv",
                    fieldSuccess: "success.field.bv",
                    fieldStatus: "status.field.bv",
                    localeChanged: "changed.locale.bv",
                    validatorError: "error.validator.bv",
                    validatorSuccess: "success.validator.bv"
                }
            }, s), "bv"),
            i.addClass("fv-form-bootstrap").data("formValidation", r).data("bootstrapValidator", r)),
            "string" == typeof e && r[e].apply(r, Array.prototype.slice.call(a, 1))
        })
    }
    ,
    t.fn.bootstrapValidator.Constructor = FormValidation.Framework.Bootstrap
}(jQuery),
function (t) {
    FormValidation.I18n = t.extend(!0, FormValidation.I18n, {
        fa_IR: {
            base64: {
                "default": "لطفا متن کد گذاری شده base 64 صحیح وارد فرمایید"
            },
            between: {
                "default": "لطفا یک مقدار بین %s و %s وارد فرمایید",
                notInclusive: "لطفا یک مقدار بین فقط %s و %s وارد فرمایید"
            },
            bic: {
                "default": "لطفا یک شماره BIC معتبر وارد فرمایید"
            },
            callback: {
                "default": "لطفا یک مقدار صحیح وارد فرمایید"
            },
            choice: {
                "default": "لطفا یک مقدار صحیح وارد فرمایید",
                less: "لطفا حداقل %s گزینه را انتخاب فرمایید",
                more: "لطفا حداکثر %s گزینه را انتخاب فرمایید",
                between: "لطفا %s - %s گزینه انتخاب فرمایید"
            },
            color: {
                "default": "لطفا رنگ صحیح وارد فرمایید"
            },
            creditCard: {
                "default": "لطفا یک شماره کارت اعتباری معتبر وارد فرمایید"
            },
            cusip: {
                "default": "لطفا یک شماره CUSIP معتبر وارد فرمایید"
            },
            cvv: {
                "default": "لطفا یک شماره CVV معتبر وارد فرمایید"
            },
            date: {
                "default": "لطفا یک تاریخ معتبر وارد فرمایید",
                min: "لطفا یک تاریخ بعد از %s وارد فرمایید",
                max: "لطفا یک تاریخ قبل از %s وارد فرمایید",
                range: "لطفا یک تاریخ در بازه %s - %s وارد فرمایید"
            },
            different: {
                "default": "لطفا یک مقدار متفاوت وارد فرمایید"
            },
            digits: {
                "default": "لطفا فقط عدد وارد فرمایید"
            },
            ean: {
                "default": "لطفا یک شماره EAN معتبر وارد فرمایید"
            },
            ein: {
                "default": "لطفا یک شماره EIN معتبر وارد فرمایید"
            },
            emailAddress: {
                "default": "لطفا آدرس ایمیل معتبر وارد فرمایید"
            },
            file: {
                "default": "لطفا فایل معتبر انتخاب فرمایید"
            },
            greaterThan: {
                "default": "لطفا مقدار بزرگتر یا مساوی با %s وارد فرمایید",
                notInclusive: "لطفا مقدار بزرگتر از %s وارد فرمایید"
            },
            grid: {
                "default": "لطفا شماره GRId معتبر وارد فرمایید"
            },
            hex: {
                "default": "لطفا عدد هگزادسیمال صحیح وارد فرمایید"
            },
            iban: {
                "default": "لطفا شماره IBAN معتبر وارد فرمایید",
                country: "لطفا یک شماره IBAN صحیح در %s وارد فرمایید",
                countries: {
                    AD: "آندورا",
                    AE: "امارات متحده عربی",
                    AL: "آلبانی",
                    AO: "آنگولا",
                    AT: "اتریش",
                    AZ: "آذربایجان",
                    BA: "بوسنی و هرزگوین",
                    BE: "بلژیک",
                    BF: "بورکینا فاسو",
                    BG: "بلغارستان",
                    BH: "بحرین",
                    BI: "بروندی",
                    BJ: "بنین",
                    BR: "برزیل",
                    CH: "سوئیس",
                    CI: "ساحل عاج",
                    CM: "کامرون",
                    CR: "کاستاریکا",
                    CV: "کیپ ورد",
                    CY: "قبرس",
                    CZ: "جمهوری چک",
                    DE: "آلمان",
                    DK: "دانمارک",
                    DO: "جمهوری دومینیکن",
                    DZ: "الجزایر",
                    EE: "استونی",
                    ES: "اسپانیا",
                    FI: "فنلاند",
                    FO: "جزایر فارو",
                    FR: "فرانسه",
                    GB: "بریتانیا",
                    GE: "گرجستان",
                    GI: "جبل الطارق",
                    GL: "گرینلند",
                    GR: "یونان",
                    GT: "گواتمالا",
                    HR: "کرواسی",
                    HU: "مجارستان",
                    IE: "ایرلند",
                    IL: "اسرائیل",
                    IR: "ایران",
                    IS: "ایسلند",
                    IT: "ایتالیا",
                    JO: "اردن",
                    KW: "کویت",
                    KZ: "قزاقستان",
                    LB: "لبنان",
                    LI: "لیختن اشتاین",
                    LT: "لیتوانی",
                    LU: "لوکزامبورگ",
                    LV: "لتونی",
                    MC: "موناکو",
                    MD: "مولدووا",
                    ME: "مونته نگرو",
                    MG: "ماداگاسکار",
                    MK: "مقدونیه",
                    ML: "مالی",
                    MR: "موریتانی",
                    MT: "مالت",
                    MU: "موریس",
                    MZ: "موزامبیک",
                    NL: "هلند",
                    NO: "نروژ",
                    PK: "پاکستان",
                    PL: "لهستان",
                    PS: "فلسطین",
                    PT: "پرتغال",
                    QA: "قطر",
                    RO: "رومانی",
                    RS: "صربستان",
                    SA: "عربستان سعودی",
                    SE: "سوئد",
                    SI: "اسلوونی",
                    SK: "اسلواکی",
                    SM: "سان مارینو",
                    SN: "سنگال",
                    TL: "تیمور شرق",
                    TN: "تونس",
                    TR: "ترکیه",
                    VG: "جزایر ویرجین، بریتانیا",
                    XK: "جمهوری کوزوو"
                }
            },
            id: {
                "default": "لطفا شماره شناسایی صحیح وارد فرمایید",
                country: "لطفا یک شماره شناسایی معتبر در %s وارد کنید",
                countries: {
                    BA: "بوسنی و هرزگوین",
                    BG: "بلغارستان",
                    BR: "برزیل",
                    CH: "سوئیس",
                    CL: "شیلی",
                    CN: "چین",
                    CZ: "چک",
                    DK: "دانمارک",
                    EE: "استونی",
                    ES: "اسپانیا",
                    FI: "فنلاند",
                    HR: "کرواسی",
                    IE: "ایرلند",
                    IS: "ایسلند",
                    LT: "لیتوانی",
                    LV: "لتونی",
                    ME: "مونته نگرو",
                    MK: "مقدونیه",
                    NL: "هلند",
                    PL: "لهستان",
                    RO: "رومانی",
                    RS: "صربی",
                    SE: "سوئد",
                    SI: "اسلوونی",
                    SK: "اسلواکی",
                    SM: "سان مارینو",
                    TH: "تایلند",
                    ZA: "آفریقای جنوبی"
                }
            },
            identical: {
                "default": "لطفا مقدار یکسان وارد فرمایید"
            },
            imei: {
                "default": "لطفا شماره IMEI معتبر وارد فرمایید"
            },
            imo: {
                "default": "لطفا شماره IMO معتبر وارد فرمایید"
            },
            integer: {
                "default": "لطفا یک عدد صحیح وارد فرمایید"
            },
            ip: {
                "default": "لطفا یک آدرس IP معتبر وارد فرمایید",
                ipv4: "لطفا یک آدرس IPv4 معتبر وارد فرمایید",
                ipv6: "لطفا یک آدرس IPv6 معتبر وارد فرمایید"
            },
            isbn: {
                "default": "لطفا شماره ISBN معتبر وارد فرمایید"
            },
            isin: {
                "default": "لطفا شماره ISIN معتبر وارد فرمایید"
            },
            ismn: {
                "default": "لطفا شماره ISMN معتبر وارد فرمایید"
            },
            issn: {
                "default": "لطفا شماره ISSN معتبر وارد فرمایید"
            },
            lessThan: {
                "default": "لطفا مقدار کمتر یا مساوی با %s وارد فرمایید",
                notInclusive: "لطفا مقدار کمتر از %s وارد فرمایید"
            },
            mac: {
                "default": "لطفا یک MAC address معتبر وارد فرمایید"
            },
            meid: {
                "default": "لطفا یک شماره MEID معتبر وارد فرمایید"
            },
            notEmpty: {
                "default": "لطفا یک مقدار وارد فرمایید"
            },
            numeric: {
                "default": "لطفا یک عدد اعشاری صحیح وارد فرمایید"
            },
            phone: {
                "default": "لطفا یک شماره تلفن صحیح وارد فرمایید",
                country: "لطفا یک شماره تلفن معتبر وارد کنید در %s",
                countries: {
                    AE: "امارات متحده عربی",
                    BG: "بلغارستان",
                    BR: "برزیل",
                    CN: "کشور چین",
                    CZ: "چک",
                    DE: "آلمان",
                    DK: "دانمارک",
                    ES: "اسپانیا",
                    FR: "فرانسه",
                    GB: "بریتانیا",
                    IN: "هندوستان",
                    MA: "مراکش",
                    NL: "هلند",
                    PK: "پاکستان",
                    RO: "رومانی",
                    RU: "روسیه",
                    SK: "اسلواکی",
                    TH: "تایلند",
                    US: "ایالات متحده آمریکا",
                    VE: "ونزوئلا"
                }
            },
            promise: {
                "default": "لطفا یک مقدار صحیح وارد فرمایید"
            },
            regexp: {
                "default": "لطفا یک مقدار مطابق با الگو وارد فرمایید"
            },
            remote: {
                "default": "لطفا یک مقدار معتبر وارد فرمایید"
            },
            rtn: {
                "default": "لطفا یک شماره RTN صحیح وارد فرمایید"
            },
            sedol: {
                "default": "لطفا یک شماره SEDOL صحیح وارد فرمایید"
            },
            siren: {
                "default": "لطفا یک شماره SIREN صحیح وارد فرمایید"
            },
            siret: {
                "default": "لطفا یک شماره SIRET صحیح وارد فرمایید"
            },
            step: {
                "default": "لطفا یک گام صحیح از %s وارد فرمایید"
            },
            stringCase: {
                "default": "لطفا فقط حروف کوچک وارد فرمایید",
                upper: "لطفا فقط حروف بزرگ وارد فرمایید"
            },
            stringLength: {
                "default": "لطفا یک مقدار با طول صحیح وارد فرمایید",
                less: "لطفا کمتر از %s حرف وارد فرمایید",
                more: "لطفا بیش از %s حرف وارد فرمایید",
                between: "لطفا مقداری بین %s و %s حرف وارد فرمایید"
            },
            uri: {
                "default": "لطفا یک آدرس URI صحیح وارد فرمایید"
            },
            uuid: {
                "default": "لطفا یک شماره UUID معتبر وارد فرمایید",
                version: "لطفا یک نسخه UUID صحیح %s شماره وارد فرمایید"
            },
            vat: {
                "default": "لطفا یک شماره VAT صحیح وارد فرمایید",
                country: "لطفا یک شماره VAT معتبر در %s وارد کنید",
                countries: {
                    AT: "اتریش",
                    BE: "بلژیک",
                    BG: "بلغارستان",
                    BR: "برزیل",
                    CH: "سوئیس",
                    CY: "قبرس",
                    CZ: "چک",
                    DE: "آلمان",
                    DK: "دانمارک",
                    EE: "استونی",
                    ES: "اسپانیا",
                    FI: "فنلاند",
                    FR: "فرانسه",
                    GB: "بریتانیا",
                    GR: "یونان",
                    EL: "یونان",
                    HU: "مجارستان",
                    HR: "کرواسی",
                    IE: "ایرلند",
                    IS: "ایسلند",
                    IT: "ایتالیا",
                    LT: "لیتوانی",
                    LU: "لوکزامبورگ",
                    LV: "لتونی",
                    MT: "مالت",
                    NL: "هلند",
                    NO: "نروژ",
                    PL: "لهستانی",
                    PT: "پرتغال",
                    RO: "رومانی",
                    RU: "روسیه",
                    RS: "صربستان",
                    SE: "سوئد",
                    SI: "اسلوونی",
                    SK: "اسلواکی",
                    VE: "ونزوئلا",
                    ZA: "آفریقای جنوبی"
                }
            },
            vin: {
                "default": "لطفا یک شماره VIN صحیح وارد فرمایید"
            },
            zipCode: {
                "default": "لطفا یک کدپستی صحیح وارد فرمایید",
                country: "لطفا یک کد پستی معتبر در %s وارد کنید",
                countries: {
                    AT: "اتریش",
                    BG: "بلغارستان",
                    BR: "برزیل",
                    CA: "کانادا",
                    CH: "سوئیس",
                    CZ: "چک",
                    DE: "آلمان",
                    DK: "دانمارک",
                    ES: "اسپانیا",
                    FR: "فرانسه",
                    GB: "بریتانیا",
                    IE: "ایرلند",
                    IN: "هندوستان",
                    IT: "ایتالیا",
                    MA: "مراکش",
                    NL: "هلند",
                    PL: "لهستان",
                    PT: "پرتغال",
                    RO: "رومانی",
                    RU: "روسیه",
                    SE: "سوئد",
                    SG: "سنگاپور",
                    SK: "اسلواکی",
                    US: "ایالات متحده"
                }
            }
        }
    })
}(jQuery);
