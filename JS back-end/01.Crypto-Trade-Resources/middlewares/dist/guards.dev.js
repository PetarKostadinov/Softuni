"use strict";

function hasUser() {
  return function (req, res, next) {
    if (req.user) {
      next();
    } else {
      res.redirect('404');
    }
  };
}

;

function isGuest() {
  return function (req, res, next) {
    if (req.user) {
      res.redirect('/'); // TODO check assignment for correct redirect
    } else {
      next();
    }
  };
}

;
module.exports = {
  hasUser: hasUser,
  isGuest: isGuest
};