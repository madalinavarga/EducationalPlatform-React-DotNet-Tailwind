const swrConfig = {
  onError: (error, key) => {
    if (error.response.status === 500) {
      window.location.href = "/error";
    }
  },
};

module.exports = swrConfig;