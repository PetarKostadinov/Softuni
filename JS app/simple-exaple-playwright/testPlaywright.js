const { chromium } = require('playwright-chromium');
const {expect} = require('chai');

(async () => {
  const browser = await chromium.launch({headless: false, slowMo:3000});
  const page = await browser.newPage();
  await page.goto('https://google.com/');
  await page.screenshot({ path: `example.png` });
  await browser.close();
})();
