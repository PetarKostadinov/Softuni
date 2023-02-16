"use strict";

var Crypto = require("../models/Crypto");

var User = require("../models/User");

function getAllCryptos() {
  return regeneratorRuntime.async(function getAllCryptos$(_context) {
    while (1) {
      switch (_context.prev = _context.next) {
        case 0:
          return _context.abrupt("return", Crypto.find({}).lean());

        case 1:
        case "end":
          return _context.stop();
      }
    }
  });
}

function createCrypto(crypto) {
  return regeneratorRuntime.async(function createCrypto$(_context2) {
    while (1) {
      switch (_context2.prev = _context2.next) {
        case 0:
          return _context2.abrupt("return", Crypto.create(crypto));

        case 1:
        case "end":
          return _context2.stop();
      }
    }
  });
}

function getById(id) {
  return regeneratorRuntime.async(function getById$(_context3) {
    while (1) {
      switch (_context3.prev = _context3.next) {
        case 0:
          return _context3.abrupt("return", Crypto.findById(id).lean());

        case 1:
        case "end":
          return _context3.stop();
      }
    }
  });
}

function deleteById(id) {
  return regeneratorRuntime.async(function deleteById$(_context4) {
    while (1) {
      switch (_context4.prev = _context4.next) {
        case 0:
          return _context4.abrupt("return", Crypto.findByIdAndDelete(id));

        case 1:
        case "end":
          return _context4.stop();
      }
    }
  });
}

function updateById(id, data, payment) {
  var existing;
  return regeneratorRuntime.async(function updateById$(_context5) {
    while (1) {
      switch (_context5.prev = _context5.next) {
        case 0:
          _context5.next = 2;
          return regeneratorRuntime.awrap(Crypto.findById(id));

        case 2:
          existing = _context5.sent;
          existing.name = data.name;
          existing.image = data.image;
          existing.price = Number(data.price);
          existing.description = data.description;
          existing.payment = data.payment;
          return _context5.abrupt("return", existing.save());

        case 9:
        case "end":
          return _context5.stop();
      }
    }
  });
}

function buy(cryptoId, userId) {
  var crypto;
  return regeneratorRuntime.async(function buy$(_context6) {
    while (1) {
      switch (_context6.prev = _context6.next) {
        case 0:
          _context6.next = 2;
          return regeneratorRuntime.awrap(Crypto.findById(cryptoId));

        case 2:
          crypto = _context6.sent;

          if (!crypto.buyCryptoUsers.includes(userId)) {
            _context6.next = 5;
            break;
          }

          throw new Error('Cannot buy twice');

        case 5:
          crypto.buyCryptoUsers.push(userId); //crypto.freeRooms -= 1;
          //bookU(cryptoId, userId);

          return _context6.abrupt("return", crypto.save());

        case 7:
        case "end":
          return _context6.stop();
      }
    }
  });
}

function bookU(cryptoId, userId) {
  var existingU;
  return regeneratorRuntime.async(function bookU$(_context7) {
    while (1) {
      switch (_context7.prev = _context7.next) {
        case 0:
          _context7.next = 2;
          return regeneratorRuntime.awrap(User.findById(userId));

        case 2:
          existingU = _context7.sent;
          existingU.booked.push(cryptoId);
          existingU.save();

        case 5:
        case "end":
          return _context7.stop();
      }
    }
  });
}

function getBookingsByUser(userId) {
  return regeneratorRuntime.async(function getBookingsByUser$(_context8) {
    while (1) {
      switch (_context8.prev = _context8.next) {
        case 0:
          return _context8.abrupt("return", Crypto.find({
            usersBooked: userId
          }).lean());

        case 1:
        case "end":
          return _context8.stop();
      }
    }
  });
} //---SEARCH


function search(searchName, searchPayment) {
  var query;
  return regeneratorRuntime.async(function search$(_context9) {
    while (1) {
      switch (_context9.prev = _context9.next) {
        case 0:
          query = {};

          if (searchName) {
            query.name = new RegExp(searchName, 'i');
          }

          if (searchPayment) {
            query.payment = new RegExp(searchPayment, 'i');
          }

          return _context9.abrupt("return", Crypto.find(query).lean());

        case 4:
        case "end":
          return _context9.stop();
      }
    }
  });
}

module.exports = {
  search: search,
  createCrypto: createCrypto,
  getById: getById,
  deleteById: deleteById,
  updateById: updateById,
  buy: buy,
  getAllCryptos: getAllCryptos,
  getBookingsByUser: getBookingsByUser
}; // async function getRecent() {
//     return Course.find({}).sort({ userCount: -1 }).limit(3).lean();
// }
// async function getAllByDate(search) {
//     let query = {};
//     if (search) {
//         query.title = new RegExp(search, 'i');
//     }
//     return Course.find(query).sort({ createdAt: 1 }).lean();
// }