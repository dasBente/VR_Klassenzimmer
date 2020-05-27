import React from 'react'
import ClassState from './containers/ClassState'

const Dashboard = () => (
  <div>
    <div className={`
      d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3
      border-bottom
      `}
    >
      <h1 className='h2 row'>Dashboard</h1>
    </div>
    <ClassState />
  </div>
)

export default Dashboard
