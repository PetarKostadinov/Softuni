
const { body, validationResult } = require('express-validator');
const { hasUser, isGuest } = require('../middlewares/guards');
const { register, login } = require('../services/userService');
const { parseError } = require('../util/parser');
const validator = require('validator');

const authController = require('express').Router();

authController.get('/register', (req, res) => {

    //TODO replace with actual view  from assignment
    res.render('register', {
        title: 'Register Page'
    });
});

authController.post('/register', 
    // body('email')
    //     .isEmail().withMessage('Please enter your email address'),
    body('username')
        .isLength({ min: 3 }).withMessage('Username must be atleast 3 characters long').bail()
        .isAlphanumeric().withMessage('Username may contains only letters and numbers'),
    body('password')
        .isLength({ min: 3 }).withMessage('Password must be atleast 3 characters long').bail()
        .isAlphanumeric().withMessage('Password may contains only letters and numbers'),

    async (req, res) => {
        try {
            const { errors } = validationResult(req);

            // if (validator.isEmail(req.body.email) == false) {
            //     throw new Error('Invalid Email')
            // }

            if (errors.length > 0) {
                throw errors;
            }

            if (req.body.password != req.body.repass) {
                throw new Error('Passwods don\'t match');
            }

            const token = await register(req.body.username, req.body.password);

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
                    //email: req.body.email,
                    username: req.body.username
                }
            })
        }
    });

authController.get('/login', (req, res) => {
    res.render('login', {
        title: 'Login Page'
    });
});

authController.post('/login', async (req, res) => {
    try {
        const token = await login(req.body.username, req.body.password);

        res.cookie('token', token);
        console.log(token)
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