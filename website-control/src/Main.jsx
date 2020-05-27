import React from 'react'
import { Dashboard } from 'components/dashboard'
import { SidebarMenu, NavBar } from 'components/Navigation'

const Main = () => (
  <>
    <NavBar />
    <div className='container-fluid'>
      <div className='row'>
        <SidebarMenu />
        <main className='col-md-9 ml-sm-auto col-lg-10 px-md-4' role='main'>
          <Dashboard />
        </main>
      </div>
    </div>
  </>
)

export default Main
