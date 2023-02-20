const authController = require("../controlers/authController");
const photoController = require("../controlers/photoController");
const homeController = require("../controlers/homeController");
const { hasUser } = require("../middlewares/guards");
const profileController = require("../controlers/profileController");

module.exports = (app) => {
    app.use('/', homeController);
    app.use('/auth', authController);
   app.use('/photo', photoController);
   app.use('/profile', profileController)
};