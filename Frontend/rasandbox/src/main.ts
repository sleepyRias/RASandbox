import Vue from "vue";
import App from "./App.vue";

// store hier rein
Vue.config.productionTip = false;
require("@/assets/main.scss");
// robert mag das nicht main erstmal verscheieben und dann "importieren"

new Vue({
  render: (h) => h(App),
}).$mount("#app");
