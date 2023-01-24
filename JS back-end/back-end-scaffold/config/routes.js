const authController = require("../controlers/authController");
const hotelController = require("../controlers/hotelController");
const homeController = require("../controlers/homeController");
const { hasUser } = require("../middlewares/guards");
const profileController = require("../controlers/profileController");

module.exports = (app) => {
    app.use('/', homeController);
    app.use('/auth', authController);
   app.use('/hotel', hasUser(), hotelController);
   app.use('/profile', profileController)
};