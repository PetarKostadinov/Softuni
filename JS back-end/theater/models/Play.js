
const { Schema, model, Types } = require('mongoose');

const URL_PATERN = /^http?:\/\/.+$/i;

const playSchema = new Schema({

    name: { type: String, required: [true, 'Title is required'] },
    description: { type: String, required: [true, 'Description is required'], maxlength: [50, 'Description must be not longer than 50 characters'] },
    image: { type: String, required: [true, 'Image is required'] },
    isPublic: { type: Boolean, default: false },
    created: { type: String, required: true, default: () => (new Date()).toISOString().slice(0, 10) },
    usersLiked: { type: [Types.ObjectId], ref: 'User', default: [] },
    count: { type: Number, default: 0 },
    owner: { type: Types.ObjectId, ref: 'User' }
});



const Play = model('Play', playSchema);

module.exports = Play;