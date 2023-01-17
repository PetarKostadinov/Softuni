const authController = require("../controlers/authController");
const postController = require("../controlers/post");
const homeController = require("../controlers/homeController");
const catalogController = require("../controlers/catalogController");
const detailsController = require("../controlers/detailsController");
const editController = require("../controlers/editController");
const deleteController = require("../controlers/deleteController");
const voteController = require("../controlers/voteController");
const myPostsController = require("../controlers/myPostsController");

module.exports = (app) => {
    app.use(homeController);
    app.use('/auth', authController);
    app.use(postController);
    app.use(catalogController);
    app.use(detailsController);
    app.use(editController);
    app.use(deleteController);
    app.use(voteController);
    app.use(myPostsController);
};