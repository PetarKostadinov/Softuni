function solve(array) {

    let myArr = [];
    let output = [];

    let command = ''
    let username = ''
    let count = 0

    array.forEach(x => {

        if (x == 'Log out') {

            let resultMessage = ''

            output.forEach(r => {
                resultMessage += `${r.name}: ${r.likes + r.comments}\n`
            })

            console.log(`${output.length} folowers\n${resultMessage}`)
            return;
        }

        myArr = x.split(': ');

        if (myArr.length == 2) {
            command = myArr[0];
            username = myArr[1];
        } else {
            command = myArr[0];
            username = myArr[1];
            count = myArr[2];
        }

        let name = output.find(x => x.name == username)
        let index = output.indexOf(name);

        if (command == 'New follower' && (!name)) {

            output.push({
                name: username,
                likes: 0,
                comments: 0
            })

        } else if (command == 'Like') {

            if (name) {
                output[index].likes += Number(count)
            } else {
                output.push({ name: username, likes: Number(count), comments: 0 })
            }

        } else if (command == 'Comment') {
            if (name) {
                output[index].comments += 1
            }
            output.push({ name: username, likes: 0, comments: 1 })

        } else if (command == 'Blocked') {

            if (name) {
                output.splice(index, 1)
            } else {
                console.log(`${username} doesn't exist`)
            }
        }
    })
}

solve([
    'New follower: George',
    'Like: George: 5',
    'New follower: George',
    'Log out'
])

solve(["Like: Katy: 3",
    "Comment: Katy",
    "New follower: Bob",
    "Blocked: Bob",
    "New follower: Amy",
    "Like: Amy: 4",
    "Log out"])

solve((["Blocked: Amy",
    "Comment: Amy",
    "New follower: Amy",
    "Like: Tom: 5",
    "Like: Ellie: 5",
    "Log out"])
)