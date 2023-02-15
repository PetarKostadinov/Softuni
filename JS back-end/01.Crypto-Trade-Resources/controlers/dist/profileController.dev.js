"use strict";

var _require = require('../middlewares/guards'),
    hasUser = _require.hasUser;

var _require2 = require('../services/cryptoService'),
    getBookingsByUser = _require2.getBookingsByUser;

var profileController = require('express').Router();

profileController.get('/', hasUser(), function _callee(req, res) {
  var booked;
  return regeneratorRuntime.async(function _callee$(_context) {
    while (1) {
      switch (_context.prev = _context.next) {
        case 0:
          _context.next = 2;
          return regeneratorRuntime.awrap(getBookingsByUser(req.user._id));

        case 2:
          booked = _context.sent;
          res.render('profile', {
            title: 'Pofile Page',
            user: Object.assign({
              booked: booked.map(function (x) {
                return x.name;
              })
            }, req.user)
          });

        case 4:
        case "end":
          return _context.stop();
      }
    }
  });
});
module.exports = profileController;