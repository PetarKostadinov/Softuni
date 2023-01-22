const authController = require("../controlers/authController");
const playController = require("../controlers/playController");
const homeController = require("../controlers/homeController");
//const hotelController = require("../controlers/hotelController");
//const profileController = require("../controlers/profileController");
const { hasUser } = require("../middlewares/guards");
const detailsController = require("../controlers/detailsController");
const editController = require("../controlers/editController");
const likeController = require("../controlers/likeController");
const deleteController = require("../controlers/deleteController");

module.exports = (app) => {
    app.use('/', homeController);
    app.use('/auth', authController);
    app.use(playController);
    app.use(detailsController);
    app.use(editController);
    app.use(likeController);
    app.use(deleteController);
};
