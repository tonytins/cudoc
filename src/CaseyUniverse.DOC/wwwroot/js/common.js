// Reads out the scroll position and stores it in the data attribute
// so we can use it in our stylesheets
const storeScroll = () => {
    document.documentElement.dataset.scroll = window.scrollY;
};

// Listen for new scroll events
document.addEventListener('scroll', storeScroll);

// Update scroll position for first time
storeScroll();