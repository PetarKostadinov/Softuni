
const { body, validationResult } = require('express-validator');
const { isGuest, hasUser } = require('../middlewares/guards');
const { register, login } = require('../services/userService');
const { parseError } = require('../util/parser');
const validator = require('validator');
const authController = require('express').Router();

authController.get('/register', isGuest(), (req, res) => {

    //TODO replace with actual view  from assignment
    res.render('register', {
        title: 'Register Page'
    });
});

authController.post('/register', isGuest(),

    async (req, res) => {
        try {
            const { errors } = validationResult(req);
            const user = await register(req.body.firstName, req.body.lastName, req.body.email, req.body.password);

            if (req.body.password.trim() == '') {
                throw new Error('Password is required');
            }

            if (req.body.password != req.body.repass) {
                throw new Error('Passwods don\'t match');
            }

            //TODO check assigment to see if register creates session
            req.session.user = user;
            res.redirect('/');
        } catch (error) {
            const errors = parseError(error);

            //TODO add error display to actual template from assignment 
            res.render('register', {
                title: 'Register Page',
                errors,
                data: {
                    firstName: req.body.firstName,
                    lastName: req.body.lastName,
                    email: req.body.email
                }
            })
        }
    });

authController.get('/login', isGuest(), (req, res) => {
    res.render('login', {
        title: 'Login Page'
    });
});

authController.post('/login', isGuest(), async (req, res) => {

    try {
        const user = await login(req.body.email, req.body.password);

        req.session.user = user;
        res.redirect('/');  // TODO replase with redirect as per assigment
    } catch (error) {
        const errors = parseError(error);
        res.render('login', {
            title: 'Login Page',
            errors,
            data: {
                email: req.body.email
            }

        });
    }
});

authController.get('/logout', hasUser(), (req, res) => {
    delete req.session.user;
    res.redirect('/');
})

module.exports = authController; 