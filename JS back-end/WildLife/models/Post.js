const { Schema, model, Types: { ObjectId } } = require('mongoose');

const URL_PATERN = /^https?:\/\/(.+)/;

const postSchema = new Schema({
    title: { type: String, required: true, minlength: [6, 'Title must be atleast 6  characters long'] },
    keyword: { type: String, required: true, minlength: [6, 'Key word must be atleast 6  characters long'] },
    location: { type: String, required: true, minlength: [15, 'Location must be atleast 15  characters long'] },
    date: {
        type: String, required: true,
        minlength: [10, 'Date must be 10  characters long'],
        maxlength: [10, 'Date must be 10  characters long'],
    },
    image: {
        type: String, required: true, validate: {
            validator(value) {
                return URL_PATERN.test(value);
            },
            message: 'Image must be valid URL'
        }
    },
    description: { type: String, required: true, minlength: [8, 'Description must be atleast 8 characters long'] },
    author: { type: ObjectId, ref: 'User', required: true },
    votes: { type: [ObjectId], ref: 'User', default: [] },
    rating: { type: Number, default: 0 }

});

const Post = model('Post', postSchema);
module.exports = Post;