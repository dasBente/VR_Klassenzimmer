import React from 'react'
import PropTypes from 'prop-types'
import Desk from './Desk'

class ClassState extends React.Component {
  /** TODO: Replace with a canvas to get a appropriate positional distribution */
  componentDidMount () {
    this.props.init()
  }

  render () {
    const { desks } = this.props

    return (
      <div className='container-fluid'>
        <div className='row row-cols-3'>
          {Object.keys(desks).map(k => (<Desk key={k} students={desks[k]} />))}
        </div>
      </div>
    )
  }
}

ClassState.propTypes = ({
  desks: PropTypes.objectOf(PropTypes.array).isRequired,
  init: PropTypes.func
})

export default ClassState
