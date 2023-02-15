const {
    body,
    validationResult
} = require('express-validator');
const {
    isGuest
} = require('../middlewares/guards');
const {
    register,
    login
} = require('../services/userService');
const {
    parseError
} = require('../util/parser');

const authController = require('express').Router();

authController.get('/register', isGuest(), (req, res) => {

    //TODO replace with actual view  from assignment
    res.render('register', {
        title: 'Register Page'
    });
});

authController.post('/register', isGuest(),
    body('username')
    .isLength({
        min: 4
    }).withMessage('The username should be at least five characters long').bail(),
    //.isAlphanumeric().withMessage('Password may contains only English letters and numbers'),
    body('password')
    .isLength({
        min: 4
    }).withMessage('Password must be atleast 4 characters long').bail(),
    //.isAlphanumeric().withMessage('Password may contains only English letters and numbers'),

    async (req, res) => {
        try {
            const {
                errors
            } = validationResult(req);

            if (errors.length > 0) {
                throw errors;
            }

            if (req.body.password != req.body.repass) {
                throw new Error('Passwods don\'t match');
            }

            const token = await register(req.body.username, req.body.email, req.body.password);

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
                    email: req.body.email,
                    username: req.body.username
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
        const token = await login(req.body.email, req.body.password);

        res.cookie('token', token);
        res.redirect('/'); // TODO replase with redirect as per assigment
    } catch (error) {
        const errors = parseError(error);
        res.render('login', {
            title: 'Login Page',
            errors,
            body: {
                email: req.body.email,

            }
        });
    }
});

authController.get('/logout', (req, res) => {
    res.clearCookie('token');
    res.redirect('/');
})



module.exports = authController;