

function attachEvents() {
    const btnLoadPosts = document.querySelector('#btnLoadPosts');
    const btnViewPost = document.querySelector('#btnViewPost');

    const dropDown = document.querySelector('#posts');

    btnLoadPosts.addEventListener('click', loadPosts);
    btnViewPost.addEventListener('click', loadComments);

    async function loadPosts(event) {

        let postsUrl = 'http://localhost:3030/jsonstore/blog/posts';

        try {

            let response = await fetch(postsUrl);
            let data = await response.json();

            Object.values(data).forEach(post => {
                let option = document.createElement('option');
                option.setAttribute('value', post.id);
                option.textContent = post.title;
                dropDown.appendChild(option);
            });

        } catch {

            throw new Error('Error loading posts in drop down');
        }
    }

    async function loadComments(event) {

        let selectedId = dropDown.options[dropDown.selectedIndex].value; //!!!        
        let currPostUrl = `http://localhost:3030/jsonstore/blog/posts/${selectedId}`;

        let postData;
        let h1 = document.querySelector('#post-title');
        let postUl = document.querySelector('#post-body');

        try {

            let postResponse = await fetch(currPostUrl);
            postData = await postResponse.json();

            h1.textContent = postData.title;
            postUl.textContent = postData.body;

        } catch {

            throw new Error('Error loading post');
        }

        let commentsUrl = ' http://localhost:3030/jsonstore/blog/comments';
        let commentsUl = document.querySelector('#post-comments');

        try {

            let commentsResponse = await fetch(commentsUrl);
            let commentsData = await commentsResponse.json();

            commentsUl.innerHTML = '';

            Object.values(commentsData).forEach(c => {

                if (c.postId === postData.id) {
                    let li = document.createElement('li');
                    li.setAttribute('id', c.id);
                    li.textContent = c.text;
                    commentsUl.appendChild(li);
                }
            });

        } catch {

            throw new Error('Error loading comments');
        }
    }
}

attachEvents();






// function attachEvents() {
//     const btnLoadPosts = document.getElementById('btnLoadPosts').addEventListener('click', getAllPosts);
//     const btnViewPost = document.getElementById('btnViewPost').addEventListener('click', displayPosts);

//     async function displayPosts() {

//         const selectedId = document.getElementById('posts').value;

//         const titleEl = document.getElementById('post-title');
//         const bodyEl = document.getElementById('post-body');
//         const ulElement = document.getElementById('post-comments');
//         titleEl.textContent = 'Loading...';
//          bodyEl.textContent = '';
//         ulElement.replaceChildren();

//         let [post, comments] = await Promise.all([
//             getPostById(selectedId),
//             getCommentsByPostsId(selectedId)

//         ])

//         titleEl.textContent = post[selectedId].title;
//         bodyEl.textContent = post[selectedId].body;

//         comments.forEach(x => {

//             const liElement = document.createElement('li');
//             liElement.textContent = x.text;
//             ulElement.appendChild(liElement);
//         })
//     }

//     async function getAllPosts() {

//         const url = `http://localhost:3030/jsonstore/blog/posts`;
//         const res = await fetch(url);
//         const data = await res.json();

//         //parse data and populate list
//         const selectElement = document.getElementById('posts');
//         selectElement.replaceChildren();
//         Object.values(data).forEach(x => {
//             const optionElement = document.createElement('option');
//             optionElement.textContent = x.title;
//             optionElement.value = x.id;
//             selectElement.appendChild(optionElement);
//         })
//     }

//     async function getPostById(postId) {
//         const url = `http://localhost:3030/jsonstore/blog/posts`// + postId;

//         const res = await fetch(url);

//         if (res.status !== 200) {

//             throw new Error('Not found')
//         }

//         const data = await res.json();
//         return data;
//     }

//     async function getCommentsByPostsId(postId) {
//         const url = `http://localhost:3030/jsonstore/blog/comments`;

//         const res = await fetch(url);
//         if (res.status !== 200) {

//             throw new Error('Not found')

//         }
//         const data = await res.json();
//         const comments = Object.values(data).filter(x => x.postId == postId);
//         return comments;


//     }
// }

// attachEvents();