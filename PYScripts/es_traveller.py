import numpy as np
from scipy import stats

#N dispari
velocity = np.array([113, 124, 124, 132, 146, 151, 170])

velocity_median = np.median(velocity)
velocity_moda = stats.mode(velocity)[0]

#N pari
preventivi = np.array([366, 327, 274, 292, 274, 230])
preventivi = np.sort(preventivi)

preventivi_median = np.median(preventivi)
preventivi_moda = stats.mode(preventivi)[0]