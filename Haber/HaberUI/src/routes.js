
import layout from './template/layout/layout.svelte'
import emptyLayout from './template/layout/empty-layaut.svelte'

import dashboard from  './view/dashboard.svelte'
import signIn from './view/sign-in.svelte'
import signUp from './view/sign-up.svelte'


import kategoriListe from './view/kategori/liste.svelte'
import kategoriEkle from './view/kategori/ekle.svelte'
import kategoriDuzenle from './view/kategori/duzenle.svelte'


import icerikListe from './view/icerik/liste.svelte'
import icerikEkle from './view/icerik/ekle.svelte'
import icerikDuzenle from './view/icerik/duzenle.svelte'
import icerikfotograflar from './view/icerik/fotograflar.svelte'


function userIsAdmin() {
  let token  = localStorage.getItem('token')
  if(token==undefined || token==null){
    return false;
  }
  return true;
}

const routes = [
  {
    name: '/',
    component: dashboard,
    redirectTo: '/admin',
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
    onlyIf: { guard: userIsAdmin, redirect: '/sign-in' },
    nestedRoutes: [
      { name: 'index', component: dashboard },
    ],
  },
  { name: 'kategori',
    component: layout,
    onlyIf: { guard: userIsAdmin, redirect: '/sign-in' },
        nestedRoutes: [
          { name: 'liste', component: kategoriListe },
          { name: 'ekle', component: kategoriEkle },
          { name: 'duzenle/:id', component: kategoriDuzenle },
        ]
  },
  { name: 'icerik',
    component: layout,
    onlyIf: { guard: userIsAdmin, redirect: '/sign-in' },
        nestedRoutes: [
          { name: 'liste', component: icerikListe },
          { name: 'ekle', component: icerikEkle },
          { name: 'duzenle/:id', component: icerikDuzenle },
          { name: 'fotograflar/:id', component: icerikfotograflar },
        ]
  }
]

export { routes }