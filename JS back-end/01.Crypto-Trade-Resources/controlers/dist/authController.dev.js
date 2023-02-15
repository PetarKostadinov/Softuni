"use strict";

var _require = require('express-validator'),
    body = _require.body,
    validationResult = _require.validationResult;

var _require2 = require('../middlewares/guards'),
    isGuest = _require2.isGuest;

var _require3 = require('../services/userService'),
    register = _require3.register,
    login = _require3.login;

var _require4 = require('../util/parser'),
    parseError = _require4.parseError;

var authController = require('express').Router();

authController.get('/register', isGuest(), function (req, res) {
  //TODO replace with actual view  from assignment
  res.render('register', {
    title: 'Register Page'
  });
});
authController.post('/register', isGuest(), body('username').isLength({
  min: 4
}).withMessage('The username should be at least five characters long').bail(), //.isAlphanumeric().withMessage('Password may contains only English letters and numbers'),
body('password').isLength({
  min: 4
}).withMessage('Password must be atleast 4 characters long').bail(), //.isAlphanumeric().withMessage('Password may contains only English letters and numbers'),
function _callee(req, res) {
  var _validationResult, errors, token, _errors;

  return regeneratorRuntime.async(function _callee$(_context) {
    while (1) {
      switch (_context.prev = _context.next) {
        case 0:
          _context.prev = 0;
          _validationResult = validationResult(req), errors = _validationResult.errors;

          if (!(errors.length > 0)) {
            _context.next = 4;
            break;
          }

          throw errors;

        case 4:
          if (!(req.body.password != req.body.repass)) {
            _context.next = 6;
            break;
          }

          throw new Error('Passwods don\'t match');

        case 6:
          _context.next = 8;
          return regeneratorRuntime.awrap(register(req.body.username, req.body.email, req.body.password));

        case 8:
          token = _context.sent;
          //TODO check assigment to see if register creates session
          res.cookie('token', token);
          res.redirect('/');
          _context.next = 17;
          break;

        case 13:
          _context.prev = 13;
          _context.t0 = _context["catch"](0);
          _errors = parseError(_context.t0); //TODO add error display to actual template from assignment 

          res.render('register', {
            title: 'Register Page',
            errors: _errors,
            body: {
              email: req.body.email,
              username: req.body.username
            }
          });

        case 17:
        case "end":
          return _context.stop();
      }
    }
  }, null, null, [[0, 13]]);
});
authController.get('/login', isGuest(), function (req, res) {
  res.render('login', {
    title: 'Login Page'
  });
});
authController.post('/login', isGuest(), function _callee2(req, res) {
  var token, errors;
  return regeneratorRuntime.async(function _callee2$(_context2) {
    while (1) {
      switch (_context2.prev = _context2.next) {
        case 0:
          _context2.prev = 0;
          _context2.next = 3;
          return regeneratorRuntime.awrap(login(req.body.email, req.body.password));

        case 3:
          token = _context2.sent;
          res.cookie('token', token);
          res.redirect('/'); // TODO replase with redirect as per assigment

          _context2.next = 12;
          break;

        case 8:
          _context2.prev = 8;
          _context2.t0 = _context2["catch"](0);
          errors = parseError(_context2.t0);
          res.render('login', {
            title: 'Login Page',
            errors: errors,
            body: {
              email: req.body.email
            }
          });

        case 12:
        case "end":
          return _context2.stop();
      }
    }
  }, null, null, [[0, 8]]);
});
authController.get('/logout', function (req, res) {
  res.clearCookie('token');
  res.redirect('/');
});
module.exports = authController;