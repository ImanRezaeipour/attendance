﻿define(["spa.engine.infrastructure.router"], function () { function r(r) { function e(r, e) { crossroads.parse(r) } hasher.changed.add(e), hasher.initialized.add(e), hasher.init(), r && hasher.setHash(r) } function e(r, e) { return crossroads.addRoute(r, e) } return { addRoute: e, start: r } });