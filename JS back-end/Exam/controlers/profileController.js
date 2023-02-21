const { hasUser } = require('../middlewares/guards');
const { getAllPhotosByUserId } = require('../services/photoService');

const profileController = require('express').Router();

profileController.get('/', hasUser(), async (req, res) => {
    
    const current = [];
    created = await getAllPhotosByUserId(req.user._id);
    
    for(let i = 0; i < created.length; i++) {

        current.push(created[i].image)
    }
   
    res.render('profile', {
        title: 'Pofile Page',
        current,
        created,
        user: Object.assign({ total: created.map(x => x.username) }, req.user)
    });
});

module.exports = profileController;