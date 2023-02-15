"use strict";

var authController = require("../controlers/authController");

var hotelController = require("../controlers/hotelController");

var homeController = require("../controlers/homeController");

var _require = require("../middlewares/guards"),
    hasUser = _require.hasUser;

var profileController = require("../controlers/profileController");

module.exports = function (app) {
  app.use('/', homeController);
  app.use('/auth', authController);
  app.use('/crypto', hotelController); //app.use('/profile', profileController)
};