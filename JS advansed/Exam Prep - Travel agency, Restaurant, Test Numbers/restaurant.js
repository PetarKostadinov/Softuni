class Restaurant {


    constructor(budgetMoney) {
        this.budgetMoney = budgetMoney
        this.menu = {}
        this.stockProducts = {}
        this.history = []

    }

    loadProducts(arr) {

        for (let el of arr) {

            let [productName, productQuantity, productTotalPrice] = el.split(' ')

            if (Number(productTotalPrice) <= this.budgetMoney) {

                if (this.stockProducts[productName]) {

                    this.stockProducts[productName] += Number(productQuantity)

                } else {

                    this.stockProducts[productName] = Number(productQuantity)
                }

                this.budgetMoney -= Number(productTotalPrice)

                this.history.push(`Successfully loaded ${productQuantity} ${productName}`)
            } else {

                this.history.push(`There was not enough money to load ${productQuantity} ${productName}`)
            }

        }

        return this.history.join('\n')
    }
    addToMenu(meal, needed, price) {

        let neededProducts = []

        for (let el of needed) {

            let [productName, productQuantity] = el.split(' ')

            let obj = {
                productName,
                productQuantity
            }

            neededProducts.push(obj)
        }

        if (this.menu[meal]) {

            return `The ${meal} is already in the our menu, try something different.`

        } else {

            this.menu[meal] = { neededProducts, price: Number(price) }

            let count = (Object.keys(this.menu)).length;

            if (count == 1) {

                return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`
            } else if (count == 0 || count > 1) {

                return `Great idea! Now with the ${meal} we have ${count} meals in the menu, other ideas?`
            }
        }
    }
    showTheMenu() {

        let count = (Object.keys(this.menu)).length

        if (count > 0) {

            let arr = []
            Object.keys(this.menu).forEach(x => arr.push([`${x} - $ ${this.menu[x].price}`]))

            return arr.join('\n').trimEnd()

        } else {

            return `Our menu is not ready yet, please come later...`
        }
    }
    makeTheOrder(meal) {

        let target = this.menu[meal]

        if (target == undefined) {

            return `There is not ${meal} yet in our menu, do you want to order something else?`

        } else {

            let currProducts = target.neededProducts;

            for (let el of currProducts) {

                if (!this.stockProducts[(el.productName)]) {
                    return `For the time being, we cannot complete your order (${meal}), we are very sorry...`
                }
                if (this.stockProducts[(el.productName)] < el.productQuantity) {

                    return `For the time being, we cannot complete your order (${meal}), we are very sorry...`
                }
            }

            for (let el of currProducts) {

                this.stockProducts[(el.productName)] -= Number(el.productQuantity)
            }

            this.budgetMoney += target.price;

            return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${target.price}.`

        }
    }
}
let kitchen = new Restaurant(1000);
console.log(kitchen.loadProducts(['Banana 10 5', 'Banana 20 10', 'Strawberries 50 30', 'Yogurt 10 10', 'Yogurt 500 1500', 'Honey 5 50']));

