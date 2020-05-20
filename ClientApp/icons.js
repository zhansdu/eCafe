import { library } from '@fortawesome/fontawesome-svg-core'
// Official documentation available at: https://github.com/FortAwesome/vue-fontawesome
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'

import { faBell,faUtensils,faNewspaper,faGlassCheers,faHome,faPhoneSquare,faShoppingBasket,faClock,faTags,faPen,faTrash,faAngleDoubleLeft,faRedo,faCity } from '@fortawesome/free-solid-svg-icons'

// If not present, it won't be visible within the application. Considering that you
// don't want all the icons for no reason. This is a good way to avoid importing too many
// unnecessary things.
library.add(
  faBell,
  faUtensils,
  faNewspaper,
  faGlassCheers,
  faHome,
  faPhoneSquare,
  faShoppingBasket,
  faClock,
  faTags,
  faPen,
  faTrash,
  faAngleDoubleLeft,
  faRedo,
  faCity
)

export {
  FontAwesomeIcon
}
