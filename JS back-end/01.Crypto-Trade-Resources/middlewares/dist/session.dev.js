"use strict";

var _require = require("../services/userService"),
    verifyToken = _require.verifyToken;

module.exports = function () {
  return function (req, res, next) {
    var token = req.cookies.token;

    if (token) {
      try {
        var userData = verifyToken(token);
        req.user = userData;
        res.locals.email = userData.email;
        res.locals.username = userData.username;
      } catch (err) {
        res.clearCookie('token');
        res.redirect('/auth/login');
        return;
      }
    }

    next();
  };
};