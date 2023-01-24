const { hasUser } = require('../middlewares/guards');
const { getBookingsByUser, getById } = require('../services/hotelService');

const profileController = require('express').Router();

profileController.get('/', hasUser(), async (req, res) => {

    const booked = await getBookingsByUser(req.user._id);

    res.render('profile', {
        title: 'Pofile Page',
        user: Object.assign({ booked: booked.map(x => x.name) }, req.user)
    });
});

module.exports = profileController;