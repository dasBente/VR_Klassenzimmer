import React from 'react'
import PropTypes from 'prop-types'
import StudentState from './containers/StudentState'
import ToggleAll from './ToggleAll'
import BehaviourControls from './BehaviourControls'

class ClassState extends React.Component {
  /** TODO: Replace with a canvas to get a appropriate positional distribution */
  componentDidMount () {
    this.props.init()
  }

  render () {
    const { students, selectAll } = this.props

    return (
      <div>
        <div className='row card-columns'>
          {students.map(s => <StudentState key={s.id} student={s} />)}
        </div>
        <div className='row float-right'><ToggleAll toggle={selectAll} /></div>
        <BehaviourControls />
      </div>
    )
  }
}

ClassState.propTypes = ({
  students: PropTypes.arrayOf(PropTypes.object).isRequired,
  init: PropTypes.func,
  selectAll: PropTypes.func
})

export default ClassState
