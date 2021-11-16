
import layout from './template/layout/layout.svelte'
import emptyLayout from './template/layout/empty-layaut.svelte'

import dashboard from  './view/dashboard.svelte'
import signIn from './view/sign-in.svelte'
import signUp from './view/sign-up.svelte'
const routes = [
  {
    name: '/',
    component: dashboard,
    layout: layout,
  },
  {
    name: 'sign-in',
    component: signIn,
    layout: emptyLayout,
  },
  {
    name: 'sign-up',
    component: signUp,
    layout: emptyLayout,
  },
  {
    name: 'admin',
    component: layout,
    nestedRoutes: [
      { name: 'index', component: dashboard },
    ],
  },
]

export { routes }