import React from 'react'
import PropTypes from 'prop-types'
import Desk from './Desk'

class ClassState extends React.Component {
  componentDidMount () {
    this.props.init()
  }

  render () {
    const { desks } = this.props
    return (<div>{desks.map((d, i) => (<Desk key={i} desk={d} />))}</div>)
  }
}

ClassState.propTypes = ({
  desks: PropTypes.arrayOf(PropTypes.object).isRequired,
  init: PropTypes.func
})

export default ClassState
