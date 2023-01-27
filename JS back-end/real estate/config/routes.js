const authController = require("../controlers/authController");
const apartController = require("../controlers/apartController");
const homeController = require("../controlers/homeController");
const { hasUser } = require("../middlewares/guards");
//const profileController = require("../controlers/profileController");

module.exports = (app) => {
    app.use('/', homeController);
    app.use('/auth', authController);
   app.use('/apart', apartController);
   //app.use('/profile', profileController)
};