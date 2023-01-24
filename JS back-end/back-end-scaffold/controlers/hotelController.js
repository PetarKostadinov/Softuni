const { createHotel, getById, deleteById, updateById, bookH } = require('../services/hotelService');
const { parseError } = require('../util/parser');

const hotelController = require('express').Router();

hotelController.get('/create', (req, res) => {
    res.render('create', {
        title: 'Create Hotel'
    });
});

hotelController.post('/create', async (req, res) => {
    const hotel = {

        name: req.body.name,
        city: req.body.city,
        freeRooms: Number(req.body.freeRooms),
        image: req.body.image,
        owner: req.user._id
    };

    try {
        if (Object.values(hotel).some(x => !x)) {
            throw new Error('All fields are required');
        }

        await createHotel(hotel, hotel.name);
        res.redirect('/');
    } catch (error) {
        res.render('create', {
            title: 'Create Hotel',
            body: hotel,
            errors: parseError(error)
        });
    }
});

hotelController.get('/:id/details', async (req, res) => {
    const hotel = await getById(req.params.id);

    hotel.isOwner = hotel.owner.toString() == req.user._id.toString();

    hotel.isBooked = hotel.usersBooked.map(x => x.toString()).includes(req.user._id.toString());

    res.render('details', {
        title: hotel.title,
        hotel
    });
});

hotelController.get('/:id/delete', async (req, res) => {
    const hotel = await getById(req.params.id);

    if (hotel.owner.toString() != req.user._id.toString()) {
        return res.redirect('/auth/login')
    }

    await deleteById(req.params.id);
    res.redirect('/');
});

hotelController.get('/:id/edit', async (req, res) => {
    const hotel = await getById(req.params.id);
    res.render('edit', {
        title: 'Edit hotel',
        hotel
    });

});

hotelController.post('/:id/edit', async (req, res) => {
    const hotel = await getById(req.params.id);

    if (hotel.owner.toString() != req.user._id.toString()) {
        return res.redirect('/auth/login');
    }

    const edited = {
        title: req.body.title,
        name: req.body.name,
        city: req.body.ci,
        image: req.body.image,
        owner: req.user._id
    };

    try {
        if (Object.values(edited).some(x => !x)) {
            return new Error('All fields are required');
        }

        await updateById(req.params.id, edited);
        res.redirect(`/hotel/${req.params.id}`);
    } catch (error) {
        const errors = parseError(error);
        //hotel._id = req.params.id;
        res.render('edit', {
            title: 'Edit hotel',
            hotel: Object.assign(edited, { _id: req.params.id }),
            errors
        });
    }
});

hotelController.get('/:id/book', async (req, res) => {
    const hotel = await getById(req.params.id);

    try {
        if (hotel.owner.toString() == req.user._id.toString()) {
            hotel.isOwner =true;
            throw new Error('Cannot book your own hotel')
        }

        await bookH(req.params.id, req.user._id);
        res.redirect(`/hotel/${req.params.id}/details`);

    } catch (err) {

        res.render('details', {
            title: 'Hotel Details',
            hotel,
            errors: parseError(err)
        })
    }
})



module.exports = hotelController;



// hotelController.post('/create', async (req, res) => {
//     const hotel = {
//         title: req.body.title,
//         description: req.body.description,
//         imageUrl: req.body.imageUrl,
//         duration: req.body.duration,
//         owner: req.user._id
//     };

//     try {
//         await createhotel(hotel);
//         res.redirect('/');
//     } catch (error) {
//         res.render('create', {
//             title: 'Create hotel',
//             errors: parseError(error),
//             body: hotel
//         });
//     }

// });

// hotelController.get('/:id/edit', async (req, res) => {
//     const hotel = await getById(req.params.id);
//     res.render('edit', {
//         title: 'Edit hotel',
//         hotel
//     });

// });

// hotelController.post('/:id/edit', async (req, res) => {
//     const hotel = await getById(req.params.id);

//     if (hotel.owner.toString() != req.user._id.toString()) {
//         return res.redirect('/auth/login');
//     }

//     try {
//         await updateById(req.params.id, req.body);
//         res.redirect(`/hotel/${req.params.id}`);
//     } catch (error) {
//         res.render('edit', {
//             title: 'Edit hotel',
//             errors: parseError(error),
//             hotel: req.body
//         });
//     }
// });

// hotelController.get('/:id/enroll', async (req, res) => {
//     const hotel = await getById(req.params.id);

//     if (hotel.owner.toString() != req.user._id.toString()
//         && hotel.users.map(x => x.toString()).includes(req.user._id.toString()) == false) {

//         await enrollUser(req.params.id, req.user._id);
//     }

//     res.redirect(`/hotel/${req.params.id}`);
// });

