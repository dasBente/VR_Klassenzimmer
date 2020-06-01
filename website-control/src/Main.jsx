import React from 'react'
import Dashboard from './pages/Dashboard'
import './sidebar.css'

const NavBar = () => (
  <nav className='navbar navbar-dark sticky-top bg-dark flex-md-nowrap p-0 shadow'>
    <a className='navbar-brand col-md-3 col-lg-2 mr-0 px-3' href='#'>VR Classroom</a>
    <button
      className='navbar-toggler position-absolute d-md-none collapsed'
      type='button'
      data-toggle='collapse'
      data-target='#sidebarMenu'
      aria-controls='sidebarMenu'
      aria-expanded='false'
      aria-label='Toggle navigation'
    >
      <span className='navbar-toggler-icon' />
    </button>
  </nav>
)

const SidebarMenu = () => (
  <nav id='sidebarMenu' className='col-md-3 col-lg-2 d-md-block bg-light sidebar collapse'>
    <div className='sidebar-sticky pt-3'>
      <ul className='nav flex-column'>
        <li className='nav-item'>
          <a className='nav-link active' href='#'>
            {/* Add icon maybe? */}
            Dashboard
          </a>
        </li>
      </ul>
    </div>
  </nav>
)

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
