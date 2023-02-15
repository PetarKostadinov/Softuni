"use strict";

var _require = require('../services/cryptoService'),
    getAllCryptos = _require.getAllCryptos;

var homeController = require('express').Router(); //TODO replace with real cotroller


homeController.get('/', function _callee(req, res) {
  var view, hotels;
  return regeneratorRuntime.async(function _callee$(_context) {
    while (1) {
      switch (_context.prev = _context.next) {
        case 0:
          hotels = [];

          if (!req.user) {
            _context.next = 8;
            break;
          }

          view = 'home';
          _context.next = 5;
          return regeneratorRuntime.awrap(getAllCryptos());

        case 5:
          hotels = _context.sent;
          _context.next = 12;
          break;

        case 8:
          view = 'home';
          _context.next = 11;
          return regeneratorRuntime.awrap(getAllCryptos());

        case 11:
          hotels = _context.sent;

        case 12:
          res.render(view, {
            title: 'Home Page',
            hotels: hotels
          });

        case 13:
        case "end":
          return _context.stop();
      }
    }
  });
});
module.exports = homeController;