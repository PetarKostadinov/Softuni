function parseError(error) {
    if (error.name == 'ValidationError') {
        return Object.values(error.errors).map(v => v.message);
    } else if (Array.isArray(error)) {
        return error.map(x => x.msg);
    } else {
        return error.message.split('\n');
    }
}

function postViewModels(post) {
    return {
        _id: post._id,
        title: post.title,
        keyword: post.keyword,
        location: post.location,
        date: post.date,
        image: post.image,
        description: post.description,
        author: authorViewModel(post.author),
        votes: post.votes.map(voterViewModel),
        rating: post.rating
    }
}

function voterViewModel(user) {
    return {
        _id: user._id,
        email: user.email,
    }
}

function authorViewModel(user) {
    return {
        _id: user._id,
        firstName: user.firstName,
        lastName: user.lastName
    };
}

module.exports = {
    parseError,
    postViewModels
}