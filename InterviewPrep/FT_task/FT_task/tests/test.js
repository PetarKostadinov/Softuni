const {chromium} = require("playwright-chromium");
const {expect} = require('chai');

let browser, page;
describe('E2E tests', async function () {
    this.timeout(5000);
    before(async () => {browser = await chromium.launch({headless: false})});
    after(async () => {await browser.close();});
    beforeEach(async () => {page = await browser.newPage();});
    afterEach(async () => {await page.close();});

    it('loads items from given api API', async () => {
        await page.goto('http://127.0.0.1:5500/index.html');
        await page.waitForSelector('.markets-data__items li>a>span');
        await page.screenshot({path: 'tests/testingScreenshot.png'});
    })

    it('loads and shows  list items names by symbols', async () => {
        await page.goto('http://127.0.0.1:5500/index.html');
        await page.waitForSelector('.markets-data__items li>a>span');
        const content = await page.textContent('.markets-data__items');
        expect(content).to.contain('Euro/Dollar');
        expect(content).to.contain('S&P 500');
        expect(content).to.contain('Brent Crude Oil');
        expect(content).to.contain('Pound/Dollar');
        expect(content).to.contain('FTSE 100');
    })
    it('builds and shows the title', async () => {
        await page.goto('http://127.0.0.1:5500/index.html');
        await page.waitForSelector('.title');
        const content = await page.textContent('header a.title');
        expect(content).to.contain('Financial Times');
    })
    it('shows + for positive or −  for negative percentage', async () => {
        await page.goto('http://127.0.0.1:5500/index.html');
        const negativeNumber = await page.$('.markets-data__item-change--down');
        const positiveNumber = await page.$('.markets-data__item-change--up');
        if (negativeNumber) {
            const content = await page.textContent('.markets-data__item-change--down');
            expect(content).to.contain('−');
        }
        if (positiveNumber) {
            const content = await page.textContent('.markets-data__item-change--up');
            expect(content).to.contain('+');
        }
    })

    it('goes to Euro/Dollar details page when item is clicked', async () => {
        await page.goto('http://127.0.0.1:5500/index.html');
        await page.waitForSelector('.markets-data__items li>a>span');
        page.waitForEvent("popup");
        await page.getByText('Euro/Dollar').click();
        await page.waitForSelector('.mod-tearsheet-overview__header__container h1');
        const visible = await page.isVisible('text=Euro/US Dollar FX Spot Rate')
        expect(visible).to.be.true
    })

    it('goes to Pound/Dollar details page when item is clicked', async () => {
        await page.goto('http://127.0.0.1:5500/index.html');
        await page.waitForSelector('.markets-data__items li>a>span');
        page.waitForEvent("popup");
        await page.getByText('Pound/Dollar').click();
        await page.waitForSelector('.mod-tearsheet-overview__header__container h1');
        const visible = await page.isVisible('text=UK Pound Sterling/US Dollar FX Spot Rate')
        expect(visible).to.be.true
    })
    it('goes to S&P 500 details page when item is clicked', async () => {
        await page.goto('http://127.0.0.1:5500/index.html');
        await page.waitForSelector('.markets-data__items li>a>span');
        page.waitForEvent("popup");
        await page.getByText('S&P 500').click();
        await page.waitForSelector('.mod-tearsheet-overview__header__container h1');
        const visible = await page.isVisible('text=S&P 500 INDEX')
        expect(visible).to.be.true
    })
    it('goes to FTSE 100 details page when item is clicked', async () => {
        await page.goto('http://127.0.0.1:5500/index.html');
        await page.waitForSelector('.markets-data__items li>a>span');
        page.waitForEvent("popup");
        await page.getByText('FTSE 100').click();
        await page.waitForSelector('.mod-tearsheet-overview__header__container h1');
        const visible = await page.isVisible('text=FTSE 100 Index')
        expect(visible).to.be.true
    })
    it('goes to Brent Crude Oil details page when item is clicked', async () => {
        await page.goto('http://127.0.0.1:5500/index.html');
        await page.waitForSelector('.markets-data__items li>a>span');
        page.waitForEvent("popup");
        await page.getByText('Brent Crude Oil').click();
        await page.waitForSelector('.mod-tearsheet-overview__header__container h1');
        const visible = await page.isVisible('text=ICE Brent Crude Oil Front Month')
        expect(visible).to.be.true
    })
})

