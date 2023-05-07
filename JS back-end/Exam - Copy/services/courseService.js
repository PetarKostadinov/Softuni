const Course = require("../models/Course");
const User = require("../models/User");

async function getAllCourses() {
    return Course.find({}).lean();
}

async function getAllCoursesSorted() {
    return Course.find({}).sort({ usersEnroled: -1 }).limit(3).lean();
}

async function createCourse(course, title) {

    const existingU = await Course.findOne({ title }).collation({ locale: 'en', strength: 2 });
    if (existingU) {
        throw new Error('Course name is taken');
    }

    return Course.create(course);
}

async function getById(id) {
    return Course.findById(id).lean();
}

async function deleteById(id) {
    return Course.findByIdAndDelete(id);
}

async function updateById(id, data) {

    const existing = await Course.findById(id);

    existing.title = data.title;
    existing.description = data.description;
    existing.image = data.image;
    existing.duration = data.duration;

    return existing.save();
}

async function enrol(courseId, userId) {
    const course = await Course.findById(courseId);
    if (course.usersEnroled.includes(userId)) {
        throw new Error('Cannot enrol twice')
    }

    course.usersEnroled.push(userId);
    //Course.freeRooms -= 1;

    //bookU(courseId, userId);

    return course.save();
}

async function getAllByDate(search) {

    let query = {};
    
    if(search) {
        query.title = new RegExp(search, 'i');
    }
    return Course.find(query).sort({created: 1}).lean();
}

async function search(searchName) {
    let query = {};
  
    if (searchName) {

        query.title = new RegExp(searchName, 'i');
       
       
    }
    // if (searchPayment) {

      
    //     query.payment = new RegExp(searchPayment, 'i');
        
    // }


    return Course.find(query).lean();

   
}

async function bookU(CourseId, userId) {

    const existingU = await User.findById(userId);

    existingU.booked.push(CourseId);

    existingU.save();
}

async function getBookingsByUser(userId) {
    return Course.find({ usersBooked: userId }).lean();
}

module.exports = {
    getAllCoursesSorted,
    search,
    createCourse,
    getById,
    deleteById,
    updateById,
    enrol,
    getAllCourses,
    getBookingsByUser,
    getAllByDate
}

// async function getRecent() {
//     return Course.find({}).sort({ userCount: -1 }).limit(3).lean();
// }

// async function getAllByDate(search) {
//     let query = {};
//     if (search) {

//         query.title = new RegExp(search, 'i');
//     }

//     return Course.find(query).sort({ createdAt: 1 }).lean();
// }

