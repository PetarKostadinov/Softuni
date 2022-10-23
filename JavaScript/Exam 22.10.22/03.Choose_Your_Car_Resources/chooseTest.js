const { chooseYourCar } = require('./chooseYourCar')
const { expect } = require('chai')

describe("chooseYourCar …", function () {

    describe("choosingType …", function () {

        it("throw error if invalid year", function () {
            expect(() => chooseYourCar.choosingType('Sedan', 'red', 1899)).to.throw(Error, "Invalid Year!")
            expect(() => chooseYourCar.choosingType('Sedan', 'red', 2023)).to.throw(Error, "Invalid Year!")
        });
        it("throw error if diffrent from Sedan", function () {
            expect(() => chooseYourCar.choosingType('combi', 'red', 1900)).to.throw(Error, "This type of car is not what you are looking for.")
            
        });
        it("If the year of the car is greater or equal to 2010, return the string: ", function () {
            expect(chooseYourCar.choosingType('Sedan', 'red', 2011)).to.equal("This red Sedan meets the requirements, that you have.")
            expect(chooseYourCar.choosingType('Sedan', 'red', 2010)).to.equal("This red Sedan meets the requirements, that you have.")
        });
        it("If the year of the car is before 2010 ", function () {
            expect(chooseYourCar.choosingType('Sedan', 'red', 2009)).to.equal("This Sedan is too old for you, especially with that red color.")
           
        });
    });


    describe("brandName …", function () {

        it("remove an element (brand) from the array that is located on the index ", function () {
            expect(chooseYourCar.brandName(["BMW", "Toyota", "Peugeot"], 0)).to.equal("Toyota, Peugeot")
            expect(chooseYourCar.brandName(["BMW", "Toyota", "Peugeot"], 2)).to.equal("BMW, Toyota")
            
        });

        it(" Throw erorr if invalid info", function () {
            expect(() => chooseYourCar.brandName(({BMW : 1}, 0))).to.throw(Error, "Invalid Information!")
            expect(() => chooseYourCar.brandName((["BMW", "Toyota", "Peugeot"], -1))).to.throw(Error, "Invalid Information!")
            expect(() => chooseYourCar.brandName((["BMW", "Toyota", "Peugeot"], 4))).to.throw(Error, "Invalid Information!")
            expect(() => chooseYourCar.brandName(("BMW, Toyota", 1))).to.throw(Error, "Invalid Information!")
            expect(() => chooseYourCar.brandName((["BMW, Toyota"], '0'))).to.throw(Error, "Invalid Information!")
        });
    });


    describe("carFuelConsumption …", function () {

        it("TODO …", function () {
            expect(chooseYourCar.carFuelConsumption(100, 5)).to.equal("The car is efficient enough, it burns 5.00 liters/100 km.")
            expect(chooseYourCar.carFuelConsumption(100, 7)).to.equal("The car is efficient enough, it burns 7.00 liters/100 km.")
            expect(chooseYourCar.carFuelConsumption(100, 8)).to.equal("The car burns too much fuel - 8.00 liters!")
        });
        it("TODO …", function () {
            expect(() => chooseYourCar.carFuelConsumption(-1, 5)).to.throw(Error, "Invalid Information!")
            expect(() => chooseYourCar.carFuelConsumption(-1, -5)).to.throw(Error, "Invalid Information!")
            expect(() => chooseYourCar.carFuelConsumption(100, -5)).to.throw(Error, "Invalid Information!")
            expect(() => chooseYourCar.carFuelConsumption('100', -5)).to.throw(Error, "Invalid Information!")
            expect(() => chooseYourCar.carFuelConsumption(100, '5')).to.throw(Error, "Invalid Information!")
        });
    });
    // TODO: …
});
