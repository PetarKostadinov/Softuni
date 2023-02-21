
const { body, validationResult } = require('express-validator');
const { hasUser, isGuest } = require('../middlewares/guards');
const { register, login } = require('../services/userService');
const { parseError } = require('../util/parser');

const authController = require('express').Router();

authController.get('/register', isGuest(), (req, res) => {

    //TODO replace with actual view  from assignment
    res.render('register', {
        title: 'Register Page'
    });
});

authController.post('/register',  isGuest(),
    body('username')
        .isLength({ min: 2 }).withMessage('Username must be atleast 2 characters long').bail(),
    body('email')
        .isLength({ min: 10 }).withMessage('Email must be atleast 10 characters long').bail(),
    body('password')
        .isLength({ min: 4 }).withMessage('Password must be atleast 4 characters long').bail(),
     

    async (req, res) => {
        try {
            const { errors } = validationResult(req);

            if (errors.length > 0) {
                throw errors;
            }

            if (req.body.username == '' || req.body.email == '' || req.body.password == '') {
                throw new Error('All fields are required!');
            }

            if (req.body.password != req.body.repass) {
                throw new Error('Passwods don\'t match');
            }

            const token = await register( req.body.username, req.body.email, req.body.password);

            //TODO check assigment to see if register creates session
            res.cookie('token', token);
            res.redirect('/');
        } catch (error) {
            const errors = parseError(error);

            //TODO add error display to actual template from assignment 
            res.render('register', {
                title: 'Register Page',
                errors,
                body: {
                    username: req.body.username,
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
        const token = await login(req.body.username, req.body.password);

        if (req.body.username == '' || req.body.password == '') {
            throw new Error('All fields are required!');
        }

        res.cookie('token', token);
        res.redirect('/');  // TODO replase with redirect as per assigment
    } catch (error) {
        const errors = parseError(error);
        res.render('login', {
            title: 'Login Page',
            errors,
            body: {
                username: req.body.username
            }
        });
    }
});

authController.get('/logout', (req, res) => {
    res.clearCookie('token');
    res.redirect('/');
})



module.exports = authController; 