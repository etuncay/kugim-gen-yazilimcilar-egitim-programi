
import layout from './template/layout/layout.svelte'
import { emptyLayout } from './template/layout/empty-layaut.svelte'

import dashboard from  './view/dashboard.svelte'

const routes = [
 
  {
    name: 'admin',
    component: layout,
    nestedRoutes: [
      { name: 'index', component: dashboard },
    ],
  },
]

export { routes }