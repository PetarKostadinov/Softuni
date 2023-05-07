const { createCourse, getById, deleteById, updateById, enrol } = require('../services/courseService');
const { parseError } = require('../util/parser');

const courseController = require('express').Router();

courseController.get('/create', (req, res) => {
    res.render('create', {
        title: 'Create Course'
    });
});

courseController.post('/create', async (req, res) => {
    const course = {

        title: req.body.title,
        description: req.body.description,
        image: req.body.image,
        duration: req.body.duration,
        owner: req.user._id
        //created: req.body.created
       
    };

    try {
        if (Object.values(course).some(x => !x)) {
            throw new Error('All fields are required');
        }

        await createCourse(course, course.title);
        res.redirect('/');
    } catch (error) {
        res.render('create', {
            title: 'Create Course',
            body: course,
            errors: parseError(error)
        });
    }
});

courseController.get('/:id/details', async (req, res) => {
    const course = await getById(req.params.id);

    if(req.user){
        course.isOwner = course.owner.toString() == req.user._id.toString();

        course.isEnroled = course.usersEnroled.map(x => x.toString()).includes(req.user._id.toString());
    

    }
   
    res.render('details', {
        title: course.title,
        course
    });
});

courseController.get('/:id/delete', async (req, res) => {
    const course = await getById(req.params.id);

    if (course.owner.toString() != req.user._id.toString()) {
        return res.redirect('/auth/login')
    }

    await deleteById(req.params.id);
    res.redirect('/');
});

courseController.get('/:id/edit', async (req, res) => {
    const course = await getById(req.params.id);
    res.render('edit', {
        title: 'Edit Course',
        course
    });

});

courseController.post('/:id/edit', async (req, res) => {
    const course = await getById(req.params.id);

    if (course.owner.toString() != req.user._id.toString()) {
        return res.redirect('/auth/login');
    }

    const edited = {
        title: req.body.title,
        description: req.body.description,
        image: req.body.image,
        duration: req.body.duration,
        owner: req.user._id
    };

    try {
        if (Object.values(edited).some(x => !x)) {
            return new Error('All fields are required');
        }

        await updateById(req.params.id, edited);
        res.redirect(`/course/${req.params.id}/details`);
    } catch (error) {
        const errors = parseError(error);
        //Course._id = req.params.id;
        res.render('edit', {
            title: 'Edit Course',
            course: Object.assign(edited, { _id: req.params.id }),
            errors
        });
    }
});

courseController.get('/:id/enrol', async (req, res) => {
    const course = await getById(req.params.id);

    try {
        if (course.owner.toString() == req.user._id.toString()) {
            course.isOwner =true;
            throw new Error('Cannot enrol your own Course')
        }

        await enrol(req.params.id, req.user._id);
        res.redirect(`/course/${req.params.id}/details`);

    } catch (err) {

        res.render('details', {
            title: 'Course Details',
            course,
            errors: parseError(err)
        })
    }
})



module.exports = courseController;



// courseController.post('/create', async (req, res) => {
//     const Course = {
//         title: req.body.title,
//         description: req.body.description,
//         imageUrl: req.body.imageUrl,
//         duration: req.body.duration,
//         owner: req.user._id
//     };

//     try {
//         await createCourse(Course);
//         res.redirect('/');
//     } catch (error) {
//         res.render('create', {
//             title: 'Create Course',
//             errors: parseError(error),
//             body: Course
//         });
//     }

// });

// courseController.get('/:id/edit', async (req, res) => {
//     const Course = await getById(req.params.id);
//     res.render('edit', {
//         title: 'Edit Course',
//         Course
//     });

// });

// courseController.post('/:id/edit', async (req, res) => {
//     const Course = await getById(req.params.id);

//     if (Course.owner.toString() != req.user._id.toString()) {
//         return res.redirect('/auth/login');
//     }

//     try {
//         await updateById(req.params.id, req.body);
//         res.redirect(`/Course/${req.params.id}`);
//     } catch (error) {
//         res.render('edit', {
//             title: 'Edit Course',
//             errors: parseError(error),
//             Course: req.body
//         });
//     }
// });

// courseController.get('/:id/enroll', async (req, res) => {
//     const Course = await getById(req.params.id);

//     if (Course.owner.toString() != req.user._id.toString()
//         && Course.users.map(x => x.toString()).includes(req.user._id.toString()) == false) {

//         await enrollUser(req.params.id, req.user._id);
//     }

//     res.redirect(`/Course/${req.params.id}`);
// });

