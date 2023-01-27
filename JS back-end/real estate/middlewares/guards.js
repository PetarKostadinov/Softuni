function hasUser() {
    return (req, res, next) => {
        if (req.user) {
            next();
        } else {
            //res.render('/auth/login');
            res.render('404');
        }
    }
};

function isGuest() {
    return (req, res, next) => {
        if (req.user) {
            res.redirect('/');  // TODO check assignment for correct redirect
        } else {
            next();
        }
    }
};

module.exports = {
    hasUser,
    isGuest
}