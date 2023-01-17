const { getPost } = require('../services/postService');
const { postViewModels } = require('../util/parser');
const catalogController = require('express').Router();

catalogController.get('/catalog', async (req, res) => {
    const posts = (await getPost()).map(postViewModels);

    res.render('catalog', {
        title: 'Catalog',
        posts
    })
})

module.exports = catalogController;