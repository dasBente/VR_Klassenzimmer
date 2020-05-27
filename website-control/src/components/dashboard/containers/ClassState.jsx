import ClassState from '../ClassState'
import { connect } from 'react-redux'
import { initStudents } from 'actions/students'

const mapStateToProps = ({ students }) => ({
  desks: students.reduce(
    (res, next) => ({
      ...res, [next.desk]: res[next.desk] ? [...res[next.desk], next] : [next]
    }),
    {}
  )
})

const mapDispatchToProps = {
  init: initStudents
}

const ClassStateContainer = connect(mapStateToProps, mapDispatchToProps)(ClassState)

export default ClassStateContainer
