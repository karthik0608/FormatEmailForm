import { createApp } from 'vue'
import App from './App.vue'
import router from './lib/router.js'

const app = createApp(App)
app.use(router).use(store).mount('#app')