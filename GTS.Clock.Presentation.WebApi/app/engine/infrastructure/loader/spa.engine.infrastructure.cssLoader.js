﻿define(function () { function e(e, t) { var n = document.createElement("link"); n.type = "text/css", n.rel = "stylesheet", n.href = e, n.onload = t, document.getElementsByTagName("head")[0].appendChild(n) } return { load: e } });