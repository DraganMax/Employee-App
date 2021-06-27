import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import Employees from '../views/Employees.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/Employees',
    name: 'Employees',
    component: Employees
  }
]

const router = new VueRouter({
  routes,
  mode: 'history'
})

export default router
