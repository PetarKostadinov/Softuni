"use strict";

var _require = require('../middlewares/guards'),
    hasUser = _require.hasUser;

var _require2 = require('../services/cryptoService'),
    createCrypto = _require2.createCrypto,
    getById = _require2.getById,
    deleteById = _require2.deleteById,
    updateById = _require2.updateById,
    buy = _require2.buy,
    getAllCryptos = _require2.getAllCryptos,
    search = _require2.search;

var _require3 = require('../util/parser'),
    parseError = _require3.parseError;

var cryptoController = require('express').Router();

cryptoController.get('/catalog', function _callee(req, res) {
  var cryptos;
  return regeneratorRuntime.async(function _callee$(_context) {
    while (1) {
      switch (_context.prev = _context.next) {
        case 0:
          _context.next = 2;
          return regeneratorRuntime.awrap(getAllCryptos());

        case 2:
          cryptos = _context.sent;
          res.render('catalog', {
            title: 'Catalog crypto',
            cryptos: cryptos
          });

        case 4:
        case "end":
          return _context.stop();
      }
    }
  });
});
cryptoController.get('/404', function (req, res) {
  res.render('404', {
    title: 'Not found'
  });
});
cryptoController.get('/create', hasUser(), function (req, res) {
  res.render('create', {
    title: 'Create crypto'
  });
});
cryptoController.post('/create', hasUser(), function _callee2(req, res) {
  var crypto;
  return regeneratorRuntime.async(function _callee2$(_context2) {
    while (1) {
      switch (_context2.prev = _context2.next) {
        case 0:
          crypto = {
            name: req.body.name,
            image: req.body.image,
            price: Number(req.body.price),
            description: req.body.description,
            payment: req.body.payment,
            buyCryptoUsers: [],
            owner: req.user._id
          };
          _context2.prev = 1;

          if (!Object.values(crypto).some(function (x) {
            return !x;
          })) {
            _context2.next = 4;
            break;
          }

          throw new Error('All fields are required');

        case 4:
          _context2.next = 6;
          return regeneratorRuntime.awrap(createCrypto(crypto));

        case 6:
          res.redirect('/crypto/catalog');
          _context2.next = 12;
          break;

        case 9:
          _context2.prev = 9;
          _context2.t0 = _context2["catch"](1);
          res.render('create', {
            title: 'Create crypto',
            body: crypto,
            errors: parseError(_context2.t0)
          });

        case 12:
        case "end":
          return _context2.stop();
      }
    }
  }, null, null, [[1, 9]]);
});
cryptoController.get('/:id/details', function _callee3(req, res) {
  var crypto;
  return regeneratorRuntime.async(function _callee3$(_context3) {
    while (1) {
      switch (_context3.prev = _context3.next) {
        case 0:
          _context3.next = 2;
          return regeneratorRuntime.awrap(getById(req.params.id));

        case 2:
          crypto = _context3.sent;

          //console.log(crypto.owner.toString())
          if (req.user) {
            crypto.isOwner = crypto.owner.toString() == req.user._id.toString();
            crypto.isBought = crypto.buyCryptoUsers.map(function (x) {
              return x.toString();
            }).includes(req.user._id.toString());
          }

          res.render('details', {
            title: crypto.title,
            crypto: crypto
          });

        case 5:
        case "end":
          return _context3.stop();
      }
    }
  });
});
cryptoController.get('/:id/delete', hasUser(), function _callee4(req, res) {
  var crypto;
  return regeneratorRuntime.async(function _callee4$(_context4) {
    while (1) {
      switch (_context4.prev = _context4.next) {
        case 0:
          _context4.next = 2;
          return regeneratorRuntime.awrap(getById(req.params.id));

        case 2:
          crypto = _context4.sent;

          if (!(crypto.owner.toString() != req.user._id.toString())) {
            _context4.next = 5;
            break;
          }

          return _context4.abrupt("return", res.redirect('/auth/login'));

        case 5:
          _context4.next = 7;
          return regeneratorRuntime.awrap(deleteById(req.params.id));

        case 7:
          res.redirect('/crypto/catalog');

        case 8:
        case "end":
          return _context4.stop();
      }
    }
  });
});
cryptoController.get('/:id/edit', hasUser(), function _callee5(req, res) {
  var crypto;
  return regeneratorRuntime.async(function _callee5$(_context5) {
    while (1) {
      switch (_context5.prev = _context5.next) {
        case 0:
          _context5.next = 2;
          return regeneratorRuntime.awrap(getById(req.params.id));

        case 2:
          crypto = _context5.sent;
          res.render('edit', {
            title: 'Edit crypto',
            crypto: crypto
          });

        case 4:
        case "end":
          return _context5.stop();
      }
    }
  });
});
cryptoController.post('/:id/edit', hasUser(), function _callee6(req, res) {
  var crypto, edited, errors;
  return regeneratorRuntime.async(function _callee6$(_context6) {
    while (1) {
      switch (_context6.prev = _context6.next) {
        case 0:
          _context6.next = 2;
          return regeneratorRuntime.awrap(getById(req.params.id));

        case 2:
          crypto = _context6.sent;

          if (!(crypto.owner.toString() != req.user._id.toString())) {
            _context6.next = 5;
            break;
          }

          return _context6.abrupt("return", res.redirect('/auth/login'));

        case 5:
          edited = {
            name: req.body.name,
            image: req.body.image,
            price: Number(req.body.price),
            description: req.body.description,
            payment: req.body.payment
          };
          _context6.prev = 6;

          if (!Object.values(edited).some(function (x) {
            return !x;
          })) {
            _context6.next = 9;
            break;
          }

          return _context6.abrupt("return", new Error('All fields are required'));

        case 9:
          _context6.next = 11;
          return regeneratorRuntime.awrap(updateById(req.params.id, edited));

        case 11:
          res.redirect("/crypto/".concat(req.params.id, "/details"));
          _context6.next = 18;
          break;

        case 14:
          _context6.prev = 14;
          _context6.t0 = _context6["catch"](6);
          errors = parseError(_context6.t0); //crypto._id = req.params.id;

          res.render('edit', {
            title: 'Edit crypto',
            crypto: Object.assign(edited, {
              _id: req.params.id
            }),
            errors: errors
          });

        case 18:
        case "end":
          return _context6.stop();
      }
    }
  }, null, null, [[6, 14]]);
});
cryptoController.get('/:id/buy', hasUser(), function _callee7(req, res) {
  var crypto;
  return regeneratorRuntime.async(function _callee7$(_context7) {
    while (1) {
      switch (_context7.prev = _context7.next) {
        case 0:
          _context7.next = 2;
          return regeneratorRuntime.awrap(getById(req.params.id));

        case 2:
          crypto = _context7.sent;
          _context7.prev = 3;

          if (!(crypto.owner.toString() == req.user._id.toString())) {
            _context7.next = 7;
            break;
          }

          crypto.isOwner = true;
          throw new Error('Cannot buy your own crypto');

        case 7:
          _context7.next = 9;
          return regeneratorRuntime.awrap(buy(req.params.id, req.user._id));

        case 9:
          res.redirect("/crypto/".concat(req.params.id, "/details"));
          _context7.next = 15;
          break;

        case 12:
          _context7.prev = 12;
          _context7.t0 = _context7["catch"](3);
          res.render('details', {
            title: 'Crypto Details',
            crypto: crypto,
            errors: parseError(_context7.t0)
          });

        case 15:
        case "end":
          return _context7.stop();
      }
    }
  }, null, null, [[3, 12]]);
});
cryptoController.get('/search', hasUser(), function _callee8(req, res) {
  var cryptos;
  return regeneratorRuntime.async(function _callee8$(_context8) {
    while (1) {
      switch (_context8.prev = _context8.next) {
        case 0:
          cryptos = []; //let justPage = false;

          if (!req.user) {
            _context8.next = 5;
            break;
          }

          _context8.next = 4;
          return regeneratorRuntime.awrap(search(req.query.search));

        case 4:
          cryptos = _context8.sent;

        case 5:
          res.render('search', {
            title: 'Search cryptos',
            cryptos: cryptos,
            search: req.query.search
          });

        case 6:
        case "end":
          return _context8.stop();
      }
    }
  });
});
module.exports = cryptoController; // cryptoController.post('/create', async (req, res) => {
//     const crypto = {
//         title: req.body.title,
//         description: req.body.description,
//         imageUrl: req.body.imageUrl,
//         duration: req.body.duration,
//         owner: req.user._id
//     };
//     try {
//         await createcrypto(crypto);
//         res.redirect('/');
//     } catch (error) {
//         res.render('create', {
//             title: 'Create crypto',
//             errors: parseError(error),
//             body: crypto
//         });
//     }
// });
// cryptoController.get('/:id/edit', async (req, res) => {
//     const crypto = await getById(req.params.id);
//     res.render('edit', {
//         title: 'Edit crypto',
//         crypto
//     });
// });
// cryptoController.post('/:id/edit', async (req, res) => {
//     const crypto = await getById(req.params.id);
//     if (crypto.owner.toString() != req.user._id.toString()) {
//         return res.redirect('/auth/login');
//     }
//     try {
//         await updateById(req.params.id, req.body);
//         res.redirect(`/crypto/${req.params.id}`);
//     } catch (error) {
//         res.render('edit', {
//             title: 'Edit crypto',
//             errors: parseError(error),
//             crypto: req.body
//         });
//     }
// });
// cryptoController.get('/:id/enroll', async (req, res) => {
//     const crypto = await getById(req.params.id);
//     if (crypto.owner.toString() != req.user._id.toString()
//         && crypto.users.map(x => x.toString()).includes(req.user._id.toString()) == false) {
//         await enrollUser(req.params.id, req.user._id);
//     }
//     res.redirect(`/crypto/${req.params.id}`);
// });